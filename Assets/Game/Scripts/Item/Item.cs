using Manor.Managers;
using UnityEngine;

namespace Manor
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private ItemInfo itemInfo;
        [SerializeField] private GameObject itemUIPanel;
        
     
        private bool _nameDisplayed;

        
        public void ShowName()
        {
            if(_nameDisplayed)            
            {                
                return;
            } 
            
            if(itemInfo && itemUIPanel)
            {
                _nameDisplayed = true;
                
                string itemName = itemInfo.itemName;
            }
        }

        public void HideName()
        {
            _nameDisplayed = false;
        }
    }
}