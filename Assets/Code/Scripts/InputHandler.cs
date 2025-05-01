using Code.Scripts.Character;

namespace Code.Scripts
{
    public class InputHandler
    {
        private PlayerController _playerController;
        private InputState _inputState;

        public InputHandler(PlayerController playerController, InputState inputState)
        {
            _playerController = playerController;
            _inputState = inputState;
        }

        public void Update()
        {
            _playerController.OnMove(_inputState);
        }
    }
}