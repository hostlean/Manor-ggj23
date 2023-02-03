using UnityEditor;
using UnityEngine;

namespace Core
{
    [CustomEditor(typeof(GameEvent))]
    public class GameEventEditor : DebuggableEditor
    {
        private GameEvent _myScript;
      
        protected override void OnEnable()
        {
            base.OnEnable();
            _myScript = (GameEvent)target;
        }

        public override void OnInspectorGUI()
        {
            
            base.OnInspectorGUI();
            
        }


        private void TestInvokeButton()
        {
            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
            if (GUILayout.Button("Test Invoke"))
            {
                _myScript.Fire();
            }
        }

        protected override void DebuggedMethods()
        {
            TestInvokeButton();
        }
    }
}