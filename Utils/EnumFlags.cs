using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumFlagsAttribute : PropertyAttribute
{
    public EnumFlagsAttribute() { }
}
#if UNITY_EDITOR
[UnityEditor.CustomPropertyDrawer(typeof(EnumFlagsAttribute))]
public class EnumFlagsAttributeDrawer : UnityEditor.PropertyDrawer
{
    public override void OnGUI(Rect _position, UnityEditor.SerializedProperty _property, GUIContent _label)
    {
        UnityEditor.EditorGUI.showMixedValue = _property.hasMultipleDifferentValues;
        UnityEditor.EditorGUI.BeginChangeCheck();
        int newValue = UnityEditor.EditorGUI.MaskField(_position, _label, _property.intValue, _property.enumNames);
        if (UnityEditor.EditorGUI.EndChangeCheck())
        {
            _property.intValue = newValue;
        }
    }
}
#endif