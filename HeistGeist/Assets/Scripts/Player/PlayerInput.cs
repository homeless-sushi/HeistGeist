using UnityEngine;

namespace Player
{
    public class PlayerInput
    {
        private static string _horizontalAxis = "Horizontal";
        private static string _verticalAxis = "Vertical";
        private static KeyCode _crouchKey = 
#if UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX
            KeyCode.LeftCommand;
#else 
            KeyCode.LeftControl;
#endif
        private static KeyCode _interactKey = KeyCode.Space;

        public Vector2 Direction => new Vector2(
            Input.GetAxisRaw(_horizontalAxis),
            Input.GetAxisRaw(_verticalAxis)
        ).normalized;
        public bool Crouch => Input.GetKey(_crouchKey);
        public bool Interact => Input.GetKeyDown(_interactKey);
    }
}