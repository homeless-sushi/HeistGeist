using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class PlayerInput
    {
        private readonly string _horizontalAxis = "Horizontal";
        private readonly string _verticalAxis = "Vertical";
        private readonly KeyCode _crouchKey = KeyCode.LeftControl;
        private readonly KeyCode _interactKey = KeyCode.Space;

        //private UnityEvent<Vector2> _directionListeners = new UnityEvent<Vector2>();
        //public UnityEvent<Vector2> DirectionListeners => _directionListeners;
        //private UnityEvent _crouchListeners = new UnityEvent();
        //public UnityEvent CrouchListeners => _crouchListeners;
        private UnityEvent _interactListeners = new UnityEvent();
        public UnityEvent InteractListeners => _interactListeners;

        public InputWrapper GetInput()
        {
            Vector2 inputDirection = new Vector2(
                UnityEngine.Input.GetAxisRaw(_horizontalAxis),
                UnityEngine.Input.GetAxisRaw(_verticalAxis)
            ).normalized;
            
            bool crouch = UnityEngine.Input.GetKey(_crouchKey);
            bool interact = UnityEngine.Input.GetKeyDown(_interactKey);
        
            //_directionListeners.Invoke(inputDirection);
            //_crouchListeners.Invoke();
            if(interact)
                _interactListeners.Invoke();

            return new InputWrapper(inputDirection, crouch, interact);
        }
    }
}