using UnityEngine;
using System;
using UnityEngine.UI;


namespace Manor.Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject startPanel;
        [SerializeField] private Button startButton;
        [SerializeField] private Button creditsButton;
        [SerializeField] private Button settingsButton;

        public event Action OnStartButtonClicked;
        public event Action OnCreditsButtonClicked;
        public event Action OnSettingsButtonClicked;
        public event Action<string,string> OnObjectDisplayed;
        
        private void Awake()
        {
            startButton.onClick.AddListener(FireOnStartButtonClicked);
            creditsButton.onClick.AddListener(FireOnCreditsButtonClicked);
            settingsButton.onClick.AddListener(FireOnSettingsButtonClicked);
        }

        private void FireOnStartButtonClicked()
        {
            Debug.Log("Clicked");
            OnStartButtonClicked?.Invoke();
            startPanel.gameObject.SetActive(false);
        }

        private void FireOnCreditsButtonClicked()
        {
            OnCreditsButtonClicked?.Invoke();
        }

        private void FireOnSettingsButtonClicked()
        {
            OnSettingsButtonClicked?.Invoke();
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