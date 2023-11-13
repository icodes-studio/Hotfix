#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace Hotfix.Demo
{
    public class ILRuntimeMenu
    {
        [MenuItem("ILRuntime/Install VS Debugger", priority = 23)]
        static void InstallDebugger()
        {
            EditorUtility.DisplayDialog(
                "Information",
                "The new version of the debugging plug-in has been submitted to the VS and VSCode store. " +
                "You can directly search for ILRuntime in the store to install it.",
                "Ok");
        }

        [MenuItem("ILRuntime/Documents", priority = 24)]
        static void OpenDocumentation()
        {
            Application.OpenURL("https://ourpalm.github.io/ILRuntime/");
        }

        [MenuItem("ILRuntime/Github", priority = 25)]
        static void OpenGithub()
        {
            Application.OpenURL("https://github.com/Ourpalm/ILRuntime");
        }

        [MenuItem("ILRuntime/Video Tutorials", priority = 26)]
        static void OpenTutorial()
        {
            Application.OpenURL("https://learn.u3d.cn/tutorial/ilruntime");
        }
    }
}
#endif
