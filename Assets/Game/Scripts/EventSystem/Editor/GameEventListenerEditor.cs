using UnityEditor;
using UnityEngine;

namespace Core
{
    [CustomEditor(typeof(GameEventListener))]
    public class GameEventListenerEditor : DebuggableEditor
    {
        private GameEventListener _myScript;

        protected override void OnEnable()
        {
            base.OnEnable();
            _myScript = (GameEventListener)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
        }

        protected override void DebuggedMethods()
        {
            TestResponseButton();
        }
        

        private void TestResponseButton()
        {
            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
            if (GUILayout.Button("Test Response"))
            {
                _myScript.response?.Invoke();
            }
        }
    }
}