using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Manor
{
    public class ObjectDisplayScreen : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _objectName;
        [SerializeField] private TextMeshProUGUI _objectDescription;


        private void Update() 
        {
            
        }

        public void Display(string objectName,string objectDescription)
        {
            // _objectName.gameObject.SetActive(isEnabled); 
            // _objectDescription.gameObject.SetActive(isEnabled);           

            _objectName.text = objectName;
            _objectDescription.text = objectDescription;
        }
        
    }    
}

