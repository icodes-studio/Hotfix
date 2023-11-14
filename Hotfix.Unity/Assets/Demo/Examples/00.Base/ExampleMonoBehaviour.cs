﻿using System.IO;
using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.Networking;
using ILRuntime.Runtime.Environment;
using ILRuntime.Mono.Cecil.Pdb;

namespace Hotfix.Demo
{
    public abstract class ExampleMonoBehaviour : MonoBehaviour
    {
        // AppDomain is the entrance to ILRuntime. It is best to save it in a singleton class. There is only one globally for the entire game.
        // For the convenience of examples, a separate one is made in each example.
        // In the official project, please create only one AppDomain globally.
        protected AppDomain domain;
        protected MemoryStream dll;
        protected MemoryStream pdb;

        protected IEnumerator Start()
        {
            // First instantiate ILRuntime's AppDomain.
            // AppDomain is an application domain. Each AppDomain is an independent sandbox.
            domain = new AppDomain();

            // In normal projects, you should download the dll from other places by yourself, or package it and read it in AssetBundle.
            // For daily development and for demonstration convenience, you should read it directly from StreamingAssets.

            // This DLL file is generated by directly compiling Hotfix.sln.
            // The output directory has been set to StreamingAssets in this project.
            // It can be generated to the corresponding directory by directly compiling it in VS without manual copying.
            // The Hotfix project directory is in \UnityRuntime\Unity\Hotfix\
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

            // The PDB file is a debugging database.
            // If you need to display the line number of the error report in the log, you must provide the PDB file.
            // However, since it will consume additional memory, please remove the PDB when it is officially released.
            // Just pass null to pdb when LoadAssembly below.
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

        protected void OnDestroy()
        {
            dll?.Close();
            pdb?.Close();
        }

        protected virtual void OnInitialize()
        {
#if DEBUG && (UNITY_EDITOR || UNITY_ANDROID || UNITY_IPHONE)
            // Unity's Profiler interface is only available on the main thread,
            // so to avoid exceptions, you need to tell ILRuntime the thread ID of the main thread
            domain.UnityMainThreadID = Thread.CurrentThread.ManagedThreadId;
#endif
        }

        protected virtual void OnHotfixLoaded()
        {
        }
    }
}