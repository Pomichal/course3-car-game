// MAD COOKIES STUDIO CUSTOM BUILD PIPELINE FOR ANDROID 
using UnityEditor;
using System.Diagnostics;
using UnityEngine;
using System;

public class CustomBuildPipeline: EditorWindow
{
    int major, minor, build;
    bool buildApk = true;
    public ScriptingImplementation scripting;
    [MenuItem("Mad Cookies Studio/Custom Build")]
    static void Init()
    {
        CustomBuildPipeline window = (CustomBuildPipeline)EditorWindow.GetWindow(typeof(CustomBuildPipeline));
        window.minSize = new Vector2(400, 600);
        window.maxSize = window.minSize;
        window.Show();
    }
    private void Awake()
    {
        string currentVersion = PlayerSettings.bundleVersion;
        major = Convert.ToInt32(currentVersion.Split('.')[0]);
        minor = Convert.ToInt32(currentVersion.Split('.')[1]);
        build = Convert.ToInt32(currentVersion.Split('.')[2]) + 1;
    }
    private void OnGUI()
    {
        EditorGUILayout.LabelField("Custom Android build pipeline", EditorStyles.boldLabel);
        EditorGUILayout.Space(10);
        ShowCurrentVersion();
    }
    private void ShowCurrentVersion()
    {
        EditorGUILayout.LabelField("Current build info ",EditorStyles.boldLabel);
        EditorGUILayout.LabelField("Bundle Version Code: " + PlayerSettings.Android.bundleVersionCode.ToString());
        EditorGUILayout.LabelField("Game Version: " + PlayerSettings.bundleVersion);
        EditorGUILayout.LabelField("New build info ", EditorStyles.boldLabel);
        GUILayout.BeginHorizontal();
        GUILayout.Space(5);
        if (GUILayout.Button("Major version++"))
        {
            major++;
        }
        if (GUILayout.Button("Minor version++"))
        {
            minor++;
        }
        if (GUILayout.Button("Build version++"))
        {
            build++;
        }

        GUILayout.Space(80);
        GUILayout.EndHorizontal();
        EditorGUILayout.LabelField("New version " + major + "." + minor + "." + build);
        buildApk = EditorGUILayout.Toggle("Build APK", buildApk);
        scripting = (ScriptingImplementation)EditorGUILayout.EnumPopup("Scripting backend", scripting);
        if (GUILayout.Button("Set backend"))
        {
            SetBackend(scripting);
        }
        GUILayout.Space(80);
        if (buildApk)
        {
            if (GUILayout.Button("Build APK"))
            {
                BuildApk();
            }
        }
        else
        {
            if (GUILayout.Button("Build AAB"))
            {
                BuildApk();
            }
        }

    }
    public void BuildApk()
    {
        EditorUserBuildSettings.buildAppBundle = false;
        PlayerSettings.bundleVersion = major + "." + minor + "." + build;
        PlayerSettings.Android.bundleVersionCode++;
        string path = EditorUtility.SaveFolderPanel("Choose Location of Built Game", "", "");
        string[] levels = new string[] { "Assets/Scenes/MainScene.unity", "Assets/Scenes/InGameScene.unity", "Assets/Scenes/UIScene.unity" };
        BuildPipeline.BuildPlayer(levels, path + "/"+ major + "." + minor + "." + build+".apk", BuildTarget.Android, BuildOptions.None);
        Process proc = new Process();
        proc.StartInfo.FileName = path + "/" + major + "." + minor + "." + build + ".apk";
        proc.Start();
    }
    public void BuildAab()
    {
        EditorUserBuildSettings.buildAppBundle = true;
        PlayerSettings.bundleVersion = major + "." + minor + "." + build;
        PlayerSettings.Android.bundleVersionCode++;
        string path = EditorUtility.SaveFolderPanel("Choose Location of Built Game", "", "");
        string[] levels = new string[] { "Assets/Scenes/MainScene.unity", "Assets/Scenes/InGameScene.unity", "Assets/Scenes/UIScene.unity" };
        BuildPipeline.BuildPlayer(levels, path + "/"+ major + "." + minor + "." + build+".aab", BuildTarget.Android, BuildOptions.None);
        Process proc = new Process();
        proc.StartInfo.FileName = path + "/" + major + "." + minor + "." + build + ".aab";
        proc.Start();
    }
    void SetBackend(ScriptingImplementation implementation)
    {
        PlayerSettings.Android.targetArchitectures = AndroidArchitecture.All;
        PlayerSettings.SetScriptingBackend(EditorUserBuildSettings.selectedBuildTargetGroup, implementation);
    }
}

