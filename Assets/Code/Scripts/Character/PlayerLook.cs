using UnityEngine;

namespace Code.Scripts.Character
{
    public class PlayerLook
    {
        private Transform _transform;
        private Vector2 _playerInput;
        private float _sensitivity = 20;

        public PlayerLook(Transform transform)
        {
            _transform = transform;
        }

        public void Look(Vector2 direction)
        {
            var mouseX = direction.x * _sensitivity * Time.deltaTime;
            var mouseY = direction.y * _sensitivity * Time.deltaTime;

            _playerInput.x += mouseX;
            _playerInput.y -= mouseY;

            _transform.localRotation = Quaternion.Euler(0f, _playerInput.x, 0f);
        }

        public Quaternion GetCameraDirection()
        {
            return Quaternion.Euler(_playerInput.y, _playerInput.x, 0f);
        }
    }
}