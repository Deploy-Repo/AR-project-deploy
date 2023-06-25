using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.XR.ARSubsystems;

[CustomEditor(typeof(StorageManager))]
public class AssetDatabaseRefresher : Editor
{/*
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        StorageManager imageLibraryDetails = (StorageManager)target;

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Referesh Asset Database", EditorStyles.boldLabel);
        AssetDatabase.Refresh();
        Debug.Log("Asset database refreshed.");
    }*/
}
