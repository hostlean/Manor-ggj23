using UnityEngine;
using Manor.Managers;

namespace Manor
{
    public class MemoryObject : MonoBehaviour
    {

        //OBJECT DISPLAY SO
        [SerializeField] ObjectDisplaySO objectDisplaySO;
        private UIManager _UIManager;
        

        private void Start() 
        {
            _UIManager = FindObjectOfType<UIManager>();
        }


        private bool _nameDisplayed;

        
        public void DisplayName()
        {
            if(_nameDisplayed)            
            {                
                return;
            } 
                
            //Display obj name
            if(objectDisplaySO && _UIManager)
            {
                _nameDisplayed = true;
                
                string _objectName = objectDisplaySO._objectName;
                string _objectDescription = objectDisplaySO._objectDescription;
                _UIManager.OnObjectDisplayed?.Invoke(_objectName, _objectDescription);
                

            }
        }

        public void UnDisplayName()
        {
            _nameDisplayed = false;
            _UIManager = FindObjectOfType<UIManager>();
            _UIManager.OnObjectDisplayed?.Invoke("", "");
        }

        

    }
}