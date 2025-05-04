using UnityEngine;

namespace Code.Scripts.Character
{
    public class PlayerLook
    {
        private Transform _transform;
        private Vector2 _playerInput;
        private float _sensitivity = 20;
        private Transform _cameraTransform;

        public PlayerLook(Transform transform, Transform cameraTransform)
        {
            _transform = transform;
            _cameraTransform = cameraTransform;
        }

        public void Look(Vector2 direction)
        {
            var mouseX = direction.x * _sensitivity * Time.deltaTime;
            var mouseY = direction.y * _sensitivity * Time.deltaTime;

            _playerInput.x += mouseX;
            _playerInput.y -= mouseY;

            _transform.localRotation = Quaternion.Euler(0f, _playerInput.x, 0f);
            _cameraTransform.localRotation = Quaternion.Euler(_playerInput.y, 0f, 0f);
        }
    }
}