using System;
using UnityEngine;

namespace Manor.Managers
{
    [DefaultExecutionOrder(-1)]
    public class GameManager : MonoBehaviour
    {
        public string GamepadControls { get; } = "Gamepad";
        public string KeyboardMouseControls  { get; } = "KeyboardMouse";
        public GameState CurrentGameState { get; private set; }

        public string CurrentControlScheme { get; private set; }
        
        public event Action<string> OnControlSchemeChanged;
        public event Action<GameState> OnGameStateChanged;

        private UIManager _uiManager;
        private void Awake()
        {
            _uiManager = FindObjectOfType<UIManager>();

            _uiManager.OnStartButtonClicked += StartGame;
            
            ChangeControlScheme(KeyboardMouseControls);
            ChangeGameState(GameState.Start);
        }

        private void StartGame()
        {
            ChangeGameState(GameState.InGame);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ChangeControlScheme(GamepadControls);
            }
        }


        public void ChangeControlScheme(string controlScheme)
        {
            CurrentControlScheme = controlScheme;
            OnControlSchemeChanged?.Invoke(CurrentControlScheme);
        }

        public void ChangeGameState(GameState stateToChange)
        {
            CurrentGameState = stateToChange;
            OnGameStateChanged?.Invoke(CurrentGameState);
        }
    }
}