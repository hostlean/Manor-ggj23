using System;
using Manor.Managers;
using TMPro;
using UnityEngine;

namespace Manor
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private ItemInfo itemInfo;
        [SerializeField] private GameObject itemUIPanel;
        [SerializeField] private TextMeshProUGUI itemNamePanel;

        private Rigidbody _rigidbody;
        
     
        private bool _nameDisplayed;

        public bool isPickable;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            HideName();
        }

        private void Start()
        {
            isPickable = true;
        }


        public void ShowName()
        {
            if(_nameDisplayed || !isPickable)            
            {                
                return;
            } 
            
            if(itemInfo && itemUIPanel)
            {
                _nameDisplayed = true;
                
                string itemName = itemInfo.itemName;

                itemNamePanel.text = itemName;
                
                itemUIPanel.SetActive(true);

            }
        }

        public void HideName()
        {
            itemUIPanel.SetActive(false);

            _nameDisplayed = false;
        }

        public void GetPicked()
        {
            _rigidbody.isKinematic = true;
            isPickable = false;
            HideName();
        }

        public void GetDropped()
        {
            _rigidbody.isKinematic = false;
            isPickable = true;
        }
        
        
    }
}