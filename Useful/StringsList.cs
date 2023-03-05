using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "NewStringsList", menuName = "Strings List", order = 99)] // выпадающее меню редактора "Create"
public class StringsList : ScriptableObject
{
    public string[] lines;
}

[System.AttributeUsage(System.AttributeTargets.Field)]
public class StringListAttribute : PropertyAttribute
{
    public string path;

    public StringListAttribute(string resourcePath)
    {
        path = resourcePath;
    }
}

#if UNITY_EDITOR

[CustomPropertyDrawer(typeof(StringListAttribute))]
public class StringSelectorPropertyDrawer : PropertyDrawer
{
    static Object current;
    static string[] options;
    static double lastTime;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var pos = EditorGUI.PrefixLabel(position, label);
        var resPath = (attribute as StringListAttribute).path;
        if (current != property.serializedObject.targetObject || EditorApplication.timeSinceStartup > lastTime + 10)
        {
            current = property.serializedObject.targetObject;
            var rp = Resources.Load<StringsList>(resPath);
            if (rp != null)
            {
                options = rp.lines;
            }
            else
            {
                options = new string[0];
            }
            lastTime = EditorApplication.timeSinceStartup;
        }
        var oldId = System.Array.IndexOf(options, property.stringValue);
        var newId = EditorGUI.Popup(pos, oldId, options);
        if (newId != oldId)
            property.stringValue = options[newId];
    }
}
#endif
