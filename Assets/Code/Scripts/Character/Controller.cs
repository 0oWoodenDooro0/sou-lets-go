using UnityEngine;

public class Controller
{
    private CharacterController _characterController;
    private Camera _camera;
    private Vector2 _lookDeltaInput;
    private Vector2 _playerInput;
    private float sensitivity = 20;
    private Transform _playerTransform;


    public Controller(CharacterController characterController, Camera camera,Transform playerTransform)
    {
        _characterController = characterController;
        _camera = camera;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _playerTransform = playerTransform;
    }
    
    public void LookUpdate()
    {
        LookRotate();
    }

    public void SetLook(Vector2 value)
    {
        _lookDeltaInput = value;
    }

    private void LookRotate()
    {
        float mouseX = _lookDeltaInput.x * sensitivity * Time.deltaTime;
        float mouseY = _lookDeltaInput.y * sensitivity * Time.deltaTime;
        
        _playerInput.x += mouseX;
        _playerInput.y -= mouseY;
        
        _playerTransform.localRotation = Quaternion.Euler(0f, _playerInput.x, 0f);
        
        _camera.transform.localRotation = Quaternion.Euler(_playerInput.y, 0f, 0f);
    }


}
