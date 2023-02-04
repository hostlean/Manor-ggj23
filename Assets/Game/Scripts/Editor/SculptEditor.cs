using UnityEditor;


namespace Manor
{
    [CustomEditor(typeof(Sculpt))]
    public class SculptEditor : CustomEditorBase
    {

        private Sculpt _myScript;
        private void OnEnable()
        {
            _myScript = (Sculpt)target;
        }

        public override void OnInspectorGUI()
        {
         
            base.OnInspectorGUI();
            
            InspectorButton("Close", _myScript.Close);
        }
    }
}