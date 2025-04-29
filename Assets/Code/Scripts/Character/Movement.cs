using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private Vector2 _inputDirection;
    private CharacterController _controller;
    private float _speed = 0f;
    private bool _isGrounded;
    private bool _isRunning;
    private float _stamina = 0f;
    
    [Header("MovementSpeed")]
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    
    [Header("Jump")]
    [SerializeField] private float jumpHeight;
    [SerializeField] private float gravity;
     private float _verticalVelocity;
    
    

    private void Start()
    {
        _controller = GetComponentInChildren<CharacterController>();
        _speed = walkSpeed;
    }

    public void OnMove(InputValue value)
    {
        _inputDirection = value.Get<Vector2>();
    }

    public void Update()
    {   
        CheckedGrounded();
        MovementUpdate();
    }

    public void OnSprint(InputValue value)
    {
        _isRunning = value.isPressed;
        if (_isRunning) _speed = runSpeed;
        else _speed = walkSpeed;
    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed && _controller.isGrounded)
        {
            _verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    private void CheckedGrounded()
    {
        if (_controller.isGrounded && _verticalVelocity < 0f)
        {
            _verticalVelocity = -2f;
        }
    }

    private void MovementUpdate()
    {
        Vector3 dir = transform.right * _inputDirection.x + transform.forward * _inputDirection.y;
        if (dir.sqrMagnitude > 1f) dir.Normalize();
        
        Vector3 move = dir * _speed;
        
        _verticalVelocity += gravity * Time.deltaTime;
        move.y = _verticalVelocity;
        
        _controller.Move(move * Time.deltaTime);
    }
    
    
}
