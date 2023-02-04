using UnityEngine;
using System;


namespace Manor.Managers
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager _instance;


        private void Awake() 
        {
            if (_instance != null && _instance != this) 
            { 
                Destroy(this); 
            } 
            else 
            { 
                _instance = this; 
            } 
        }


        public void ToggleUIElement(GameObject UI_Object,bool isEnabled)
        {
            UI_Object.SetActive(isEnabled);
        }

        public void ToggleUIChildElements(GameObject UI_Object,bool isEnabled)
        {
            Transform rootUI = UI_Object.transform;
            for (int i = 0; i < rootUI.childCount; i++)
            {
                rootUI.GetChild(i).gameObject.SetActive(isEnabled);
            }
        }

        #region Actions

        public Action _onStartGame;
        public Action _onCreditsOpened;

        #endregion
    }
}