using System;
using UnityEditor;
using UnityEngine;

namespace Manor.Editor
{
    [CustomEditor(typeof(Sculpt))]
    public class SculptEditor : UnityEditor. Editor
    {

        private Sculpt _myScript;
        private void OnEnable()
        {
            _myScript = (Sculpt)target;
        }

        public override void OnInspectorGUI()
        {
         
            base.OnInspectorGUI();
            
            if (GUILayout.Button("Open"))
            {
                _myScript.Close();
            }
        }
    }
}