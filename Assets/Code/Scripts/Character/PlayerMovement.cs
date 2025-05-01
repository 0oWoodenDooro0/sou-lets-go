using System;
using UnityEngine;

namespace Code.Scripts.Character
{
    public class PlayerMovement
    {
        private Transform _transform;
        private CharacterController _characterController;
        private float _speed = 5f;
        private bool _isGrounded;
        private bool _isRunning;
        private float _walkSpeed = 5f;
        private float _runSpeed = 10f;

        private float _jumpHeight = 2;
        private float _gravity = -20;

        private float _verticalVelocity;

        public PlayerMovement(Transform playerTransform, CharacterController characterController)
        {
            _characterController = characterController;
            _transform = playerTransform;
        }

        public void Move(Vector2 direction)
        {
            var dir = _transform.right * direction.x + _transform.forward * direction.y;
            if (dir.sqrMagnitude > 1f) dir.Normalize();

            var move = dir * _speed;

            _verticalVelocity += _gravity * Time.deltaTime;
            move.y = _verticalVelocity;

            _characterController.Move(move * Time.deltaTime);
        }

        public void Sprint(bool value)
        {
            _isRunning = value;
            _speed = _isRunning ? _runSpeed : _walkSpeed;
        }

        public void Jump(bool value)
        {
            if (value && _characterController.isGrounded)
            {
                _verticalVelocity = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
            }
        }

        public void CheckedGrounded()
        {
            if (_characterController.isGrounded && _verticalVelocity < 0f)
            {
                _verticalVelocity = -2f;
            }
        }
    }
}