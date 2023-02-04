using UnityEngine;


namespace Manor
{
    public class PlayerInputs : MonoBehaviour
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

        private void Awake()
        {
            _inputController = FindObjectOfType<InputController>();
            _inputController.OnMoveInput += OnMove;
            _inputController.OnPointerInput += OnLook;
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

        private void OnApplicationFocus(bool hasFocus)
        {
            SetCursorState(cursorLocked);
        }

        private void SetCursorState(bool newState)
        {
            Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
        }
    }
}