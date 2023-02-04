using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Manor
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Transform cameraHolder;
        [SerializeField] private float mouseInputMultiplier = .1f;
        [SerializeField] private float lowerVerticalAngleLimit = 60f;
        [SerializeField] private float upperVerticalAngleLimit = 60f;
        [SerializeField] private float cameraSpeed = 250f;
        
        private InputController _inputController;
        
      


        private void Awake()
        {
            _inputController = FindObjectOfType<InputController>();

            _inputController.OnPointerInput += RotatePlayer;

        }
        
        private float _oldHorizontalInput = 0f;
        private float _oldVerticalInput = 0f;
        private float _currentXAngle = 0f;
        private float _currentYAngle = 0f;
        private void RotatePlayer(Vector2 delta)
        {
            var horizontal = delta.normalized.x;
            var vertical = -delta.normalized.y;
            
            if(Time.timeScale > 0f && Time.deltaTime > 0f)
            {
                horizontal /= Time.deltaTime;
                horizontal *= Time.timeScale;
            }
            else
                horizontal = 0f;
            
            
            if(Time.timeScale > 0f && Time.deltaTime > 0f)
            {
                vertical /= Time.deltaTime;
                vertical *= Time.timeScale;
            }
            else
                vertical = 0f;
            
            vertical *= mouseInputMultiplier;
            horizontal *= mouseInputMultiplier;
            
            _oldHorizontalInput = horizontal;
            _oldVerticalInput = vertical;
            
            _currentXAngle += _oldVerticalInput * cameraSpeed * Time.deltaTime;
            _currentYAngle += _oldHorizontalInput * cameraSpeed * Time.deltaTime;

            //Clamp vertical rotation;
            _currentXAngle = Mathf.Clamp(_currentXAngle, -upperVerticalAngleLimit, lowerVerticalAngleLimit);

            UpdateRotation();
            
        }
        
        private Vector3 _facingDirection;
        private Vector3 _upwardsDirection;
        
        protected void UpdateRotation()
        {
            cameraHolder.localRotation = Quaternion.Euler(new Vector3(0, _currentYAngle, 0));

            //Save 'facingDirection' and 'upwardsDirection' for later;
            _facingDirection = cameraHolder.forward;
            _upwardsDirection = cameraHolder.up;

            cameraHolder.localRotation = Quaternion.Euler(new Vector3(_currentXAngle, _currentYAngle, 0));
        }
        
        
    }
}