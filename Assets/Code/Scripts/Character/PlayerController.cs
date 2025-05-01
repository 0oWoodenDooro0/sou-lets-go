using UnityEngine;
using Object = UnityEngine.Object;

namespace Code.Scripts.Character
{
    public class PlayerController : ICameraTargetInfo
    {
        private PlayerMovement _playerMovement;
        private PlayerLook _playerLook;
        private CharacterController _characterController;
        private GameObject _playerPrefab;
        private bool _playerExist;

        public PlayerController(GameObject playerPrefab)
        {
            _playerPrefab = playerPrefab;
        }

        public void Spawn(Vector3 position)
        {
            if (_playerExist) return;
            _playerExist = true;
            var instance = Object.Instantiate(_playerPrefab, position, Quaternion.identity);
            _characterController = instance.GetComponent<CharacterController>();
            var transform = instance.transform;
            _playerMovement = new PlayerMovement(transform, _characterController);
            _playerLook = new PlayerLook(transform);
        }

        public void OnMove(InputState inputState)
        {
            if (!_playerExist) return;
            _playerMovement.Sprint(inputState.IsSprint);
            _playerMovement.Jump(inputState.IsJump);
            _playerMovement.CheckedGrounded();
            _playerMovement.Move(inputState.MoveDirection);
            _playerLook.Look(inputState.LookDirection);
        }

        public Vector3 GetCameraPosition()
        {
            return _characterController.transform.position + new Vector3(0f, 0.7f, 0f) +
                   _characterController.transform.forward * 0.4f;
        }

        public Quaternion GetCameraLookAtDirection()
        {
            return _playerLook.GetCameraDirection();
        }
    }
}