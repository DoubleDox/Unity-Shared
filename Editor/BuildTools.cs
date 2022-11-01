using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class BuildTools 
{
    [MenuItem("Custom/Build/Build WebGL")]
    public static void BuildWebGL()
    {
        BuildPipeline.BuildPlayer(EditorBuildSettings.scenes , "Builds", BuildTarget.WebGL, BuildOptions.None);
    }

    [MenuItem("Custom/Build/Create WebGL batch")]
    public static void CreateWebGLBatch()
    {
        var projPath = Path.GetDirectoryName(Application.dataPath);
        File.WriteAllText(projPath + "/build_webgl.bat", 
            "\"" + EditorApplication.applicationPath +  "\" -quit -batchmode -executeMethod BuildTools.BuildWebGL -projectPath " + projPath
            );
    }


    [MenuItem("Custom/Build/Build Android")]
    public static void BuildAndroid()
    {
        BuildPipeline.BuildPlayer(EditorBuildSettings.scenes, "Builds", BuildTarget.Android, BuildOptions.None);
    }

    [MenuItem("Custom/Build/Create Android batch")]
    public static void CreateAndroidBatch()
    {
        var projPath = Path.GetDirectoryName(Application.dataPath);
        File.WriteAllText(projPath + "/build_android.bat",
            "\"" + EditorApplication.applicationPath + "\" -quit -batchmode -executeMethod BuildTools.BuildAndroid -projectPath " + projPath
            );
    }
}
