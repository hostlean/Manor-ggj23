using System;
using UnityEngine;

namespace Manor.Managers
{
    public class GameManager : MonoBehaviour
    {
        private const string GamepadControls = "Gamepad";
        private const string KeyboardMouseControls = "KeyboardMouse";
        public GameState CurrentGameState { get; private set; }
        
        public string CurrentControlScheme { get; private set; }
        
        public event Action<string> OnControlSchemeChanged;
        public event Action<GameState> OnGameStateChanged;
        private void Awake()
        {
            ChangeGameState(GameState.Start);
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