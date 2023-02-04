using Manor.Managers;
using UnityEngine;

namespace Manor
{
    public class Item : MonoBehaviour
    {
        [SerializeField]
        private ItemInfo itemInfo;

        [SerializeField] private ItemStory itemStory;
        
        private UIManager _uiManager;
        

        private void Start() 
        {
            _uiManager = FindObjectOfType<UIManager>();
        }


        private bool _nameDisplayed;

        
        public void DisplayName()
        {
            if(_nameDisplayed)            
            {                
                return;
            } 
                
            //Display obj name
            if(itemInfo && _uiManager)
            {
                _nameDisplayed = true;
                
                string _objectName = itemInfo.itemName;
                string _objectDescription = itemInfo.itemDescription;


            }
        }

        public void UnDisplayName()
        {
            _nameDisplayed = false;
            _uiManager = FindObjectOfType<UIManager>();
        }
    }
}