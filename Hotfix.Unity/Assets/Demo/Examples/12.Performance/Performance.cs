using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using ILRuntime.Runtime;
using ILRuntime.Runtime.Environment;
using ILRuntime.Mono.Cecil.Pdb;

namespace Hotfix.Demo
{
    public sealed class Performance : MonoBehaviour
    {
        public Button load;
        public Button loadRegister;
        public Button unload;
        public CanvasGroup testPanel;
        public RectTransform buttonParent;
        public Text result;

        private AppDomain domain;
        private MemoryStream dll;
        private MemoryStream pdb;
        private List<string> tests = new List<string>()
        {
            "TestMandelbrot",
            "Test0",
            "Test1",
            "Test2",
            "Test3",
            "Test4",
            "Test5",
            "Test6",
            "Test7",
            "Test8",
            "Test9",
            "Test10",
            "Test11",
        };

        private void Awake()
        {
            var template = buttonParent.GetChild(0).gameObject;
            template.SetActive(false);

            foreach (var test in tests)
            {
                var button = Instantiate(template);
                button.transform.SetParent(buttonParent);
                button.transform.localScale = Vector3.one;
                CreateTestButton(test, button);
                button.SetActive(true);
            }
        }

        private void CreateTestButton(string testName, GameObject go)
        {
            Button button = go.GetComponent<Button>();
            Text text = go.GetComponentInChildren<Text>();
            text.text = testName;
            button.onClick.AddListener(() =>
            {
                var sb = new StringBuilder();
#if UNITY_EDITOR || DEBUG
                sb.AppendLine("Please setup the project to a non-Development Build and install it on a real machine before testing.");
                sb.AppendLine("The performance difference in the editor is huge, and the current test results are not meaningful.");
                sb.AppendLine("");
#endif
                domain.Invoke("Hotfix.TestPerformance", testName, null, sb);
                result.text = sb.ToString();
            });
        }

        public void OnLoadHotfix()
        {
            domain = new AppDomain();
            StartCoroutine(LoadHotfixAssembly());
        }

        public void OnLoadHotfixviaJIT()
        {
            domain = new AppDomain(ILRuntimeJITFlags.JITImmediately);
            StartCoroutine(LoadHotfixAssembly());
        }

        public void OnUnload()
        {
            dll?.Close(); 
            pdb?.Close();

            dll = null;
            pdb = null;
            domain = null;

            load.interactable = true;
            loadRegister.interactable = true;
            unload.interactable = false;
            testPanel.interactable = false;
        }

        private IEnumerator LoadHotfixAssembly()
        {
            load.interactable = false;
            loadRegister.interactable = false;

#if UNITY_ANDROID
            using (var www = UnityWebRequest.Get(Application.streamingAssetsPath + "/Hotfix.dll"))
#else
            using (var www = UnityWebRequest.Get("file:///" + Application.streamingAssetsPath + "/Hotfix.dll"))
#endif
            {
                yield return www.SendWebRequest();

                if (www.result != UnityWebRequest.Result.Success)
                    Debug.LogError(www.error);

                dll = new MemoryStream(www.downloadHandler.data);
            }

#if UNITY_ANDROID
            using (var www = UnityWebRequest.Get(Application.streamingAssetsPath + "/Hotfix.pdb"))
#else
            using (var www = UnityWebRequest.Get("file:///" + Application.streamingAssetsPath + "/Hotfix.pdb"))
#endif
            {
                yield return www.SendWebRequest();

                if (www.result != UnityWebRequest.Result.Success)
                    Debug.LogError(www.error);

                pdb = new MemoryStream(www.downloadHandler.data);
            }

            try
            {
                domain.LoadAssembly(dll, pdb, new PdbReaderProvider());
            }
            catch
            {
                Debug.LogError("Failed to load Hotfix.dll.");
                yield break;
            }

            OnInitialize();
            OnHotfixLoaded();
        }

        private void OnInitialize()
        {
#if DEBUG && (UNITY_EDITOR || UNITY_ANDROID || UNITY_IPHONE)
            // Unity's Profiler interface is only available on the main thread,
            // so to avoid exceptions, you need to tell ILRuntime the thread ID of the main thread
            domain.UnityMainThreadID = Thread.CurrentThread.ManagedThreadId;
#endif
            domain.RegisterValueTypeBinder(typeof(Vector3), new Vector3Binder());
            domain.RegisterValueTypeBinder(typeof(Quaternion), new QuaternionBinder());
            domain.RegisterValueTypeBinder(typeof(Vector2), new Vector2Binder());
            domain.InitializeBindings();
            domain.DebugService.StartDebugService();
        }

        private void OnHotfixLoaded()
        {
            unload.interactable = true;
            testPanel.interactable = true;
        }

        private void OnDestroy()
        {
            dll?.Close();
            pdb?.Close();
        }

        public static bool MandelbrotCheck(float x, float y)
        {
            return ((x * x) + (y * y)) < 4.0f;
        }

        public static void TestFunc1(int a, string b, Transform c)
        {
        }
    }
}
