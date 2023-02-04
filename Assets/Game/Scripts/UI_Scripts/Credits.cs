using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manor.Managers;


namespace Manor.UI.Objects
{
    public class Credits : MonoBehaviour
    {
        private UIManager _uiManager;
        private void Awake()
        {
            _uiManager = FindObjectOfType<UIManager>();
        }

        public void OpenCredits()
        {
            if(_uiManager)
                _uiManager._onCreditsOpened?.Invoke();
        }
    }  
}

