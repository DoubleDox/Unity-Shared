using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class AssetPathAttribute : PropertyAttribute
{
    public Type type;
    public AssetPathAttribute(Type type) { this.type = type; }
}
#if UNITY_EDITOR
[UnityEditor.CustomPropertyDrawer(typeof(AssetPathAttribute))]
public class AssetPathAttributeDrawer : UnityEditor.PropertyDrawer
{
    UnityEngine.Object cachedAsset = null;
    SerializedObject cachedObject = null;

    public override void OnGUI(Rect _position, UnityEditor.SerializedProperty _property, GUIContent _label)
    {
        var apa = attribute as AssetPathAttribute;

        if (cachedObject == null || cachedObject != _property.serializedObject)
        {
            cachedObject = _property.serializedObject;
            var file = _property.stringValue;
            if (!file.Contains(".")) file += ".prefab";
            cachedAsset = AssetDatabase.LoadAssetAtPath(file, apa.type);
        }

        UnityEditor.EditorGUI.showMixedValue = _property.hasMultipleDifferentValues;
        UnityEditor.EditorGUI.BeginChangeCheck();
        var obj = UnityEditor.EditorGUI.ObjectField(_position, _label, cachedAsset, apa.type, false);
        if (UnityEditor.EditorGUI.EndChangeCheck())
        {
            var path = AssetDatabase.GetAssetPath(obj);
            _property.stringValue = path;
        }
    }
}
#endif