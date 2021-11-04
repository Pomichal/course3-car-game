using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Linq;
using System;

public class PersistentStorageClear : EditorWindow
{
    [SerializeField]private List<FileInfo> files;
    [MenuItem("Mad Cookies Studio/Persistent Data Clear")]
    static void Init()
    {
        PersistentStorageClear window = (PersistentStorageClear)EditorWindow.GetWindow(typeof(PersistentStorageClear));
        window.minSize = new Vector2(250, 250);
        window.Show();
    }
    private void OnGUI()
    {
        EditorGUILayout.LabelField("CLEAR PERSISTENT STORAGE?", EditorStyles.boldLabel);
        var directory = new DirectoryInfo(Application.persistentDataPath);
        files = directory.GetFiles().ToList();
        if (files.Count > 0)
        {
            EditorGUILayout.LabelField("Click on the file you want to delete", EditorStyles.helpBox);
        }
        else
        {
            EditorGUILayout.LabelField("No files in persistent storage", EditorStyles.helpBox);
        }
        foreach (var item in files)
        {
            if (GUILayout.Button(item.Name))
            {
                item.Delete();
            }
        }
        EditorGUILayout.Space(25);
        GUIStyle customButton = new GUIStyle("button");
        customButton.fontStyle = FontStyle.Bold;
        customButton.fontSize = 20;
        if(files.Count > 0)
        {
            if (GUILayout.Button(string.Format("Delete {0} files", files.Count), customButton))
            {
                ClearStorage();
            }
        }
        EditorGUILayout.Space(5);
        if(GUILayout.Button("Show in explorer"))
        {
            ShowExplorer();
        }
    }
    private void ClearStorage()
    {
        foreach (var file in files)
        {
            file.Delete();
        }
        Debug.LogFormat("{0} files deleted", files.Count);
    }
    public void ShowExplorer()
    {
        var itemPath = Application.persistentDataPath.Replace(@"/", @"\");
        EditorUtility.RevealInFinder(itemPath);
    }
}