using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    private CharacterController _characterController;
    private Camera _camera;
    private Vector2 _lookDeltaInput;
    private Vector2 _playerInput;
    [Header("Sensitivity")]
    [SerializeField] private float sensitivity;
    
    
    void Start()
    {
        _characterController = GetComponentInChildren<CharacterController>();
        _camera = GetComponentInChildren<Camera>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        float mouseX = _lookDeltaInput.x * sensitivity * Time.deltaTime;
        float mouseY = _lookDeltaInput.y * sensitivity * Time.deltaTime;
        
        _playerInput.x += mouseX;
        _playerInput.y -= mouseY;
        
        transform.localRotation = Quaternion.Euler(0f, _playerInput.x, 0f);
        
        _camera.transform.localRotation = Quaternion.Euler(_playerInput.y, 0f, 0f);
    }

    public void OnLook(InputValue value) 
    {
        _lookDeltaInput = value.Get<Vector2>();
    }
}
