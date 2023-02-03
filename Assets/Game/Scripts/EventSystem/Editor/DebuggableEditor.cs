using UnityEditor;
using UnityEngine;

namespace Core
{
    public abstract class DebuggableEditor : Editor
    {
        public bool debugEnabled;

        protected virtual void OnEnable()
        {
            debugEnabled = false;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (debugEnabled)
            {
                DebuggedMethods();
            }
            
            GUILayout.FlexibleSpace();
            GUILayout.BeginHorizontal();
            
            EnableDebuggingButton();
            
            GUILayout.EndHorizontal();
            GUILayout.FlexibleSpace();
        }

        protected abstract void DebuggedMethods();
        private void EnableDebuggingButton()
        {
            var controlRect = EditorGUILayout.GetControlRect();
            var rect = new Rect(controlRect.x, controlRect.y, 150, 20);
           
            if (!debugEnabled)
            {
                if (GUI.Button(rect ,"Enable Debugging"))
                {
                    debugEnabled = !debugEnabled;
                }
            }
            else
            {
                var color = GUI.backgroundColor;
                GUI.backgroundColor = Color.red;
                if (GUI.Button(rect ,"Disable Debugging"))
                {
                    debugEnabled = !debugEnabled;
                }

                GUI.backgroundColor = color;
            }
        }
    }
}