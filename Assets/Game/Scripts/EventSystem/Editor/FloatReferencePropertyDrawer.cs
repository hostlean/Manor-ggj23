using UnityEditor;
using UnityEngine;

namespace Core
{
    [CustomPropertyDrawer(typeof(FloatReference))]
    public class FloatReferencePropertyDrawer : PropertyDrawer
    {
        
        public override void OnGUI(Rect position, SerializedProperty property,
            GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            
            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
        
            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;
            
            var firstRect = new Rect(position.x - 20f, position.y, 20f, EditorGUIUtility.singleLineHeight);
            var secondRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);

            var referenceType = property.FindPropertyRelative("referenceType");
            var constant = property.FindPropertyRelative("constant");
            var data = property.FindPropertyRelative("data");

            // var icon = EditorGUIUtility.TrIconContent("d_Selectable Icon");
            // var style = new GUIStyle();
            //var val = (ReferenceType) EditorGUILayout.EnumPopup((ReferenceType)referenceType.intValue);
            EditorGUI.BeginChangeCheck();

            var val = (ReferenceType) EditorGUI.EnumPopup(firstRect, (ReferenceType)referenceType.enumValueIndex);
            referenceType.enumValueIndex = (int)val;
            //EditorGUI.Popup(firstRect, icon, referenceType.intValue, referenceType.enumNames);

            if (referenceType.intValue == 0)
            {
                constant.floatValue = EditorGUI.FloatField(secondRect, constant.floatValue);
            }
            else if (referenceType.intValue == 1)
            {
                EditorGUI.ObjectField(secondRect, data, GUIContent.none);
            }

            EditorGUI.EndChangeCheck();
            
            // var toggleValue =  property.FindPropertyRelative("isToggle");
            // toggleValue.boolValue = EditorGUI.Foldout(firstRect, toggleValue.boolValue, label);
            
            EditorGUI.indentLevel = indent;
            EditorGUI.IndentedRect(position);
            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            
            // var toggleValue =  property.FindPropertyRelative("isToggle");
            //
            // if (toggleValue.boolValue)
            // {
            //     return (EditorGUIUtility.singleLineHeight) + (EditorGUIUtility.singleLineHeight * 5);
            // }
            return (EditorGUIUtility.singleLineHeight);

            // return base.GetPropertyHeight(property, label);
        }
    }
}