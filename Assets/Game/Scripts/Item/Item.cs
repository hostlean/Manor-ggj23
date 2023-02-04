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
        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
            _rigidbody = GetComponent<Rigidbody>();
            HideName();
        }

        private Transform _lookAtTransform;

        private void Start()
        {
            isPickable = true;
        }

        private void Update()
        {
            if (_lookAtTransform)
            {
                var dir = _lookAtTransform.position - _transform.position;
                var lookAt = Quaternion.LookRotation(dir.normalized);
                lookAt = Quaternion.Euler(_transform.eulerAngles.x, lookAt.eulerAngles.y, lookAt.eulerAngles.z);
                
                itemUIPanel.transform.rotation = lookAt;
            }
        }


        public void ShowName(Transform targetTransform)
        {
            if(_nameDisplayed || !isPickable)            
            {                
                return;
            } 
            
            if(itemInfo && itemUIPanel)
            {
                _lookAtTransform = targetTransform;
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
            _lookAtTransform = null;
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

        public void GetThrown(Vector3 dir, float force)
        {
            GetDropped();
            _rigidbody.AddForce(dir.normalized * force, ForceMode.Impulse);
        }
        
        
    }
}