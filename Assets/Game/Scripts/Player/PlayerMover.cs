using System;
using UnityEngine;

namespace Manor
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private float movementSpeed;
        [SerializeField] private float gravity = 8f;
        [SerializeField] private Transform directionSetter;
        
        float currentVerticalSpeed = 0f;
        
        private Rigidbody _rigidbody;
        private InputController _inputController;
        
        private bool _isGrounded = false;

        public bool IsGrounded => _isGrounded;

        private Transform _transform;

        private void Awake()
        {
            _inputController = FindObjectOfType<InputController>();

            _inputController.OnMoveInput += Move;
            
            _rigidbody = GetComponent<Rigidbody>();
        }


        private void FixedUpdate()
        {
            _rigidbody.velocity -= Vector3.down * gravity;
        }

        Vector3 lastVelocity = Vector3.zero;
        
        
        
        private void Move(Vector2 pos)
        {
            var horizontal = pos.normalized.x;
            var vertical = pos.normalized.y;
            
            Vector3 _direction = Vector3.zero;
            _direction += Vector3.ProjectOnPlane(directionSetter.right, _transform.up).normalized * horizontal;
            _direction += Vector3.ProjectOnPlane(directionSetter.forward, _transform.up).normalized * vertical;

            Vector3 _velocity = Vector3.zero;
            
            _velocity += _direction * movementSpeed;
            
            if (!_isGrounded)
            {
                currentVerticalSpeed -= gravity * Time.deltaTime;
            }
            else
            {
                if (currentVerticalSpeed <= 0f)
                    currentVerticalSpeed = 0f;
            }
            
            _velocity += _transform.up * currentVerticalSpeed;

            
            lastVelocity = _velocity;

           
            SetVelocity(_velocity);
            
        }
        
        
        public void SetVelocity(Vector3 _velocity)
        {
            _rigidbody.velocity = _velocity;	
        }	
        
        
        
        
        
        
        


      
    }
}