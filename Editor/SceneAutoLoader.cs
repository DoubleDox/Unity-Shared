using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[InitializeOnLoad]
static class SceneAutoLoader
{
    [MenuItem("File/Scene Autoload/Select Master Scene...")]
    private static void SelectMasterScene()
    {
        string masterScene = EditorUtility.OpenFilePanel("Select Master Scene", Application.dataPath, "unity");
        if (!string.IsNullOrEmpty(masterScene))
        {
            if (masterScene.Contains(":"))
            {
                masterScene = "Assets/" + masterScene.Substring(Application.dataPath.Length + 1);
            }
            MasterScene = masterScene;
            enableAutoLoad();
        }
    }

    static void enableAutoLoad()
    {
        var scene = AssetDatabase.LoadAssetAtPath<SceneAsset>(MasterScene);
        EditorSceneManager.playModeStartScene = scene;
        Debug.Log("Autoload set to: " + (scene ? scene.name : null));
        LoadMasterOnPlay = true;
    }

    static void disableAutoLoad()
    {
        EditorSceneManager.playModeStartScene = null;
        LoadMasterOnPlay = false;
    }

    [MenuItem("File/Scene Autoload/Load Master On Play", true)]
    private static bool ShowLoadMasterOnPlay()
    {
        return !LoadMasterOnPlay;
    }
    [MenuItem("File/Scene Autoload/Load Master On Play")]
    private static void EnableLoadMasterOnPlay()
    {
        LoadMasterOnPlay = true;
        enableAutoLoad();
    }

    [MenuItem("File/Scene Autoload/Don't Load Master On Play", true)]
    private static bool ShowDontLoadMasterOnPlay()
    {
        return LoadMasterOnPlay;
    }
    [MenuItem("File/Scene Autoload/Don't Load Master On Play")]
    private static void DisableLoadMasterOnPlay()
    {
        LoadMasterOnPlay = false;
        disableAutoLoad();
    }

    // Properties are remembered as editor preferences.
    private const string cEditorPrefLoadMasterOnPlay = "SceneAutoLoader.LoadMasterOnPlay";
    private const string cEditorPrefMasterScene = "SceneAutoLoader.MasterScene";
    
    private static bool LoadMasterOnPlay
    {
        get { return EditorPrefs.GetBool(cEditorPrefLoadMasterOnPlay + "." + PlayerSettings.productName, false); }
        set { EditorPrefs.SetBool(cEditorPrefLoadMasterOnPlay + "." + PlayerSettings.productName, value); }
    }

    private static string MasterScene
    {
        get { return EditorPrefs.GetString(cEditorPrefMasterScene + "." + PlayerSettings.productName, "Master.unity"); }
        set { EditorPrefs.SetString(cEditorPrefMasterScene + "." + PlayerSettings.productName, value); }
    }
}