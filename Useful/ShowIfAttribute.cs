#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public class ShowIfAttribute : PropertyAttribute
{
	public string conditionField;
	public object compareValue;

	public ShowIfAttribute(string conditionField, object compareValue = null)
	{
		this.conditionField = conditionField;
		this.compareValue = compareValue;
	}
}

[CustomPropertyDrawer(typeof(ShowIfAttribute))]
public class ShowIfDrawer : PropertyDrawer
{
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		ShowIfAttribute showIf = (ShowIfAttribute)attribute;
		SerializedProperty conditionProperty = property.serializedObject.FindProperty(showIf.conditionField);

		if (conditionProperty != null && IsConditionMet(conditionProperty, showIf.compareValue))
		{
			EditorGUI.PropertyField(position, property, label, true);
		}
	}

	public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
	{
		ShowIfAttribute showIf = (ShowIfAttribute)attribute;
		SerializedProperty conditionProperty = property.serializedObject.FindProperty(showIf.conditionField);

		if (conditionProperty != null && IsConditionMet(conditionProperty, showIf.compareValue))
		{
			return EditorGUI.GetPropertyHeight(property, label);
		}
		return 0;
	}

	private bool IsConditionMet(SerializedProperty conditionProperty, object compareValue)
	{
		if (compareValue == null)
		{
			return conditionProperty.boolValue;
		}

		switch (conditionProperty.propertyType)
		{
			case SerializedPropertyType.Boolean:
				return conditionProperty.boolValue == (bool)compareValue;
			case SerializedPropertyType.Enum:
				return conditionProperty.enumValueIndex == (int)compareValue;
			case SerializedPropertyType.Integer:
				return conditionProperty.intValue == (int)compareValue;
			case SerializedPropertyType.Float:
				return Mathf.Approximately(conditionProperty.floatValue, (float)compareValue);
			case SerializedPropertyType.String:
				return conditionProperty.stringValue == (string)compareValue;
			default:
				return true;
		}
	}
}
#endif