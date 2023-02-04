using System;
using UnityEngine;
using UnityEngine.InputSystem;


namespace Manor
{
    public class InputController : MonoBehaviour
    {
        private GameInputs _gameInputs;
        
        


        private void Awake()
        {
            _gameInputs = new GameInputs();

            _gameInputs.Player.Move.performed += HandleMoveInput;


        }


        private void HandleMoveInput(InputAction.CallbackContext ctx)
        {
            var vector2 = ctx.ReadValue<Vector2>();
        }
    }
}