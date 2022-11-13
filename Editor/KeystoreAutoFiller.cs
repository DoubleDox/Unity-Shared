using UnityEngine;
using System.Collections;
using UnityEditor;

[InitializeOnLoad]
public class KeystoreAutoFiller
{
    const string KEYSTORE_PASS_KEY = "keystorePass";
    const string KEYALIAS_PASS_KEY = "keyaliasPass";

    [MenuItem("Custom/Build/Store current keystore passwords to Prefs")]
    static void StorePass()
    {
        EditorPrefs.SetString(KEYSTORE_PASS_KEY, PlayerSettings.Android.keystorePass);
        EditorPrefs.SetString(KEYALIAS_PASS_KEY, PlayerSettings.Android.keyaliasPass);
    }

    [MenuItem("Custom/Build/Clear current keystore passwords in Prefs")]
    static void ClearPass()
    {
        EditorPrefs.DeleteKey(KEYSTORE_PASS_KEY);
        EditorPrefs.DeleteKey(KEYALIAS_PASS_KEY);
    }

    static KeystoreAutoFiller()
    {
        if (EditorPrefs.HasKey(KEYSTORE_PASS_KEY))
            PlayerSettings.Android.keystorePass = EditorPrefs.GetString(KEYSTORE_PASS_KEY);
        if (EditorPrefs.HasKey(KEYALIAS_PASS_KEY))
            PlayerSettings.Android.keyaliasPass = EditorPrefs.GetString(KEYALIAS_PASS_KEY);
    }
}


