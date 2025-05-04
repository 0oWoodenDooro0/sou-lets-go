using UnityEngine;
using Object = UnityEngine.Object;

namespace Code.Scripts.Character
{
    public class PlayerController : ICameraTargetInfo
    {
        private PlayerMovement _playerMovement;
        private PlayerLook _playerLook;
        private GameObject _playerPrefab;
        private bool _playerExist;
        private Transform _cameraTransform;

        public PlayerController(GameObject playerPrefab)
        {
            _playerPrefab = playerPrefab;
        }

        public void Spawn(Vector3 position)
        {
            if (_playerExist) return;
            _playerExist = true;
            var instance = Object.Instantiate(_playerPrefab, position, Quaternion.identity);
            var characterController = instance.GetComponent<CharacterController>();
            _cameraTransform = instance.transform.Find("CameraPoint");
            // 25/05/04, user, todo: 應該有更好的方法
            var transform = instance.transform;
            _playerMovement = new PlayerMovement(transform, characterController);
            _playerLook = new PlayerLook(transform, _cameraTransform);
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
            return _cameraTransform.position;
        }

        public Quaternion GetCameraRotation()
        {
            return _cameraTransform.rotation;
        }
    }
}