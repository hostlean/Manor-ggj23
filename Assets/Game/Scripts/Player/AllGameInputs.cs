using Manor.Managers;
using UnityEngine;


namespace Manor
{
    public class AllGameInputs : MonoBehaviour
    {
        [Header("Character Input Values")] 
        public Vector2 move;
        public Vector2 look;
        public bool jump;
        public bool sprint;

        [Header("Movement Settings")] 
        public bool analogMovement;

        [Header("Mouse Cursor Settings")] 
        public bool cursorLocked = true;
        public bool cursorInputForLook = true;

        private InputController _inputController;

        private GameManager _gameManager;

        private void Awake()
        {
            _gameManager = FindObjectOfType<GameManager>();

            _gameManager.OnGameStateChanged += state =>
            {
                SetCursorState(state == GameState.InGame);
            };
            
            _inputController = FindObjectOfType<InputController>();
            _inputController.OnMoveInput += OnMove;
            _inputController.OnPointerInput += OnLook;
            
            SetCursorState(_gameManager.CurrentGameState == GameState.InGame);
        }


        public void OnMove(Vector2 vector2)
        {
            MoveInput(vector2);
        }

        public void OnLook(Vector2 vector2)
        {
            if (cursorInputForLook)
            {
                LookInput(vector2);
            }
        }

        public void OnJump()
        {
            JumpInput(true);
        }

        public void OnSprint()
        {
            SprintInput(true);
        }

        public void MoveInput(Vector2 newMoveDirection)
        {
            move = newMoveDirection;
        }

        public void LookInput(Vector2 newLookDirection)
        {
            look = newLookDirection;
        }

        public void JumpInput(bool newJumpState)
        {
            jump = newJumpState;
        }

        public void SprintInput(bool newSprintState)
        {
            sprint = newSprintState;
        }

        public void SetCursorState(bool newState)
        {
            Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
        }
    }
}