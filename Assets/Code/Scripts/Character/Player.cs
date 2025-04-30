using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{   
    private Movement _movement;
    private Controller _controller;
    private CharacterController _characterController;
    private Camera _camera;
    
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _movement = new Movement(_characterController,transform);
        _controller = new Controller(_characterController,GetComponentInChildren<Camera>(),transform);
    }
    void Update()
    {
        UpdateMovementStates();
        UpdateLookStates();
    }
    

    private void UpdateMovementStates()
    {
        _movement.CheckedGrounded();
        _movement.MovementUpdate();
    }

    private void UpdateLookStates()
    {
        _controller.LookUpdate();
    }
    
    
    public void OnMove(InputValue value)
    {
        _movement.SetInputDirection(value.Get<Vector2>());
    }

    public void OnSprint(InputValue value)
    {
        _movement.SetSprint(value.isPressed);
    }

    public void OnJump(InputValue value)
    {
        _movement.SetJump(value.isPressed);
    }

    public void OnLook(InputValue value)
    {
        _controller.SetLook(value.Get<Vector2>());
    }

    public void OnInteract(InputValue value)
    {
        
    }
    
}
