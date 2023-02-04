using System;
using UnityEngine;

namespace Manor
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 7f;
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
            _transform = transform;
            _inputController = FindObjectOfType<InputController>();

            _inputController.OnMoveInput += SetMoveValues;
            
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            FireGroundRay();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private float _horizontal;
        private float _vertical;

        private void SetMoveValues(Vector2 vector2)
        {
            _horizontal = vector2.normalized.x;
            _vertical = vector2.normalized.y;
        }

        Vector3 lastVelocity = Vector3.zero;
        
        private void Move()
        {
            Vector3 direction = Vector3.zero;
            direction += Vector3.ProjectOnPlane(directionSetter.right, _transform.up).normalized * _horizontal;
            direction += Vector3.ProjectOnPlane(directionSetter.forward, _transform.up).normalized * _vertical;

            Vector3 _velocity = Vector3.zero;
            
            _velocity += direction * movementSpeed;
            
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


        private void FireGroundRay()
        {
            var ray = new Ray(_transform.position + Vector3.up, Vector3.down);
            var isCasting = Physics.Raycast(ray, out var hitInfo, 1.1f);

            _isGrounded = hitInfo.collider != null;

        }



        public void SetVelocity(Vector3 _velocity)
        {
            _rigidbody.velocity = _velocity;	
        }	
        
        
        
        
        
        
        


      
    }
}