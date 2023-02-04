using System;
using UnityEngine;

namespace Manor.Managers
{
    public class GameManager : MonoBehaviour
    {
        private const string GamepadControls = "Gamepad";
        private const string KeyboardMouseControls = "KeyboardMouse";
        
        public string CurrentControlScheme { get; private set; }
        
        public event Action<string> OnControlSchemeChanged;
        private void Awake()
        {
            
        }

        public void ChangeControlScheme(string controlScheme)
        {
            CurrentControlScheme = controlScheme;
            OnControlSchemeChanged?.Invoke(CurrentControlScheme);
        }
    }
}