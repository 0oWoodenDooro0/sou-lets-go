using Code.Scripts.Character;
using UnityEngine;

namespace Code.Scripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private GameObject playerCamera;
        private InputHandler _inputHandler;
        private PlayerController _playerController;

        private void Awake()
        {
        }

        private void Start()
        {
            var inputState = gameObject.AddComponent<InputState>();
            _playerController = new PlayerController(playerPrefab);
            _playerController.Spawn(new Vector3(0, 1, 0));
            _inputHandler = new InputHandler(_playerController, inputState);
        }

        private void Update()
        {
            _inputHandler.Update();
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            playerCamera.transform.position = _playerController.GetCameraPosition();
            playerCamera.transform.rotation = _playerController.GetCameraLookAtDirection();
        }
    }
}