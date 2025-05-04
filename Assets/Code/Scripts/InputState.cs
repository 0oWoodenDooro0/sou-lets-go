using UnityEngine;
using UnityEngine.InputSystem;

namespace Code.Scripts
{
    public class InputState : MonoBehaviour
    {
        public Vector2 MoveDirection;
        public bool IsSprint;
        public bool IsJump;
        public Vector2 LookDirection;

        public void OnMove(InputValue value)
        {
            MoveDirection = value.Get<Vector2>();
        }

        public void OnSprint(InputValue value)
        {
            IsSprint = value.isPressed;
        }

        public void OnJump(InputValue value)
        {
            IsJump = value.isPressed;
        }

        public void OnLook(InputValue value)
        {
            LookDirection = value.Get<Vector2>();
        }

        public void OnInteract(InputValue value)
        {
        }
    }
}