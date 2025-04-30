using System;
using UnityEngine;


public class Movement
{
    private Vector2 _inputDirection;
    private CharacterController _characterController;
    private float _speed = 5f;
    private bool _isGrounded;
    private bool _isRunning;
    private float _stamina = 0f;
    

    private float walkSpeed = 5f;
    private float runSpeed = 10f;
    
    private float jumpHeight = 2;
    private float gravity = -20;
    
     private float _verticalVelocity;
     private Transform _playerTransform;

     public Movement(CharacterController characterController, Transform playerTransform)
     {
         _characterController = characterController;
         _playerTransform = playerTransform;
     }
     
    public void SetPlayerController(CharacterController controller)
    {
        _characterController = controller;
    }
    
    public void SetInputDirection(Vector2  value)
    {
        _inputDirection = value;
    }
    

    public void SetSprint(bool  value)
    {
        _isRunning = value;
        if (_isRunning) _speed = runSpeed;
        else _speed = walkSpeed;
    }

    public void SetJump(bool value)
    {
        if (value && _characterController.isGrounded)
        {
            _verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    public void CheckedGrounded()
    {
        if (_characterController.isGrounded && _verticalVelocity < 0f)
        {
            _verticalVelocity = -2f;
        }
    }

    public void MovementUpdate()
    {
        Vector3 dir = _playerTransform.right * _inputDirection.x + _playerTransform.forward * _inputDirection.y;
        if (dir.sqrMagnitude > 1f) dir.Normalize();
        
        Vector3 move = dir * _speed;
        
        _verticalVelocity += gravity * Time.deltaTime;
        move.y = _verticalVelocity;
        
        _characterController.Move(move * Time.deltaTime);
    }
    
    
}
