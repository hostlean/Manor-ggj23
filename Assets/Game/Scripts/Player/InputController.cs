using System;
using Manor.Managers;
using UnityEngine;
using UnityEngine.InputSystem;


namespace Manor
{
    public class InputController : MonoBehaviour
    {
        private GameInputs _gameInputs;

        public event Action<Vector2> OnMoveInput;
        public event Action<Vector2> OnPointerInput;
        public event Action OnInteractionInput;
        public event Action OnBackInput;
        public event Action OnInventoryInput;

        private GameManager _gameManager;

        private bool _disablePlayerInput;




        private void Awake()
        {
            _gameManager = FindObjectOfType<GameManager>();

            _gameManager.OnGameStateChanged += state =>
            {
                ChangePlayerInputStatus(state != GameState.InGame);
            };
            
           
            
            _gameInputs = new GameInputs();

            _gameInputs.Player.Move.performed += HandleMoveInput;
            _gameInputs.Player.Move.canceled += HandleMoveInput;
            _gameInputs.Player.PointerMovement.performed += HandlePointerMovementInput;
            _gameInputs.Player.PointerMovement.canceled += HandlePointerMovementInput;
            _gameInputs.Player.Interaction.started += HandleInteractionInput;
            _gameInputs.Player.Back.started += HandleBackInput;
            _gameInputs.Player.Inventory.started += HandleInventoryInput;
            
            _gameInputs.Enable();

            _disablePlayerInput = _gameManager.CurrentGameState != GameState.InGame;

        }


        private void HandleMoveInput(InputAction.CallbackContext ctx)
        {
           if(_disablePlayerInput) return;
            
            var vector2 = ctx.ReadValue<Vector2>();
            OnMoveInput?.Invoke(vector2);
        }

        private void HandlePointerMovementInput(InputAction.CallbackContext ctx)
        {
            if(_disablePlayerInput) return;
            
            var vector2 = ctx.ReadValue<Vector2>();
            OnPointerInput?.Invoke(vector2);
        }

        private void HandleInteractionInput(InputAction.CallbackContext ctx)
        {
            if(_disablePlayerInput) return;
            
            OnInteractionInput?.Invoke();
        }

        private void HandleBackInput(InputAction.CallbackContext ctx)
        {
            OnBackInput?.Invoke();
        }

        private void HandleInventoryInput(InputAction.CallbackContext ctx)
        {
            if(_disablePlayerInput) return;
            
            OnInventoryInput?.Invoke();
        }

        private void ChangePlayerInputStatus(bool disable)
        {
            _disablePlayerInput = disable;
        }
    }
}