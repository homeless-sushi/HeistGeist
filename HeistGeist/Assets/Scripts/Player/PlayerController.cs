using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(MovingObject))]
    public class PlayerController : MonoBehaviour
    {
        public static readonly State.IState IdleState = new State.Idle();
        public static readonly State.IState WalkState = new State.Walk();
        public static readonly State.IState SlideState = new State.Slide();
        public static readonly State.IState CrouchState = new State.Crouch();
        
        public Animator Animator { get; private set; }
        private MovingObject _movingObject;
        
        private State.IState _state;
        private State.IState State {
            get => _state;
            set {
                _state.OnExit(this);
                _state = value;
                _state.OnEnter(this);
            }
        }

        //A class for reading input
        private PlayerInput _inputReader;
        public UnityEvent InteractEvent => _inputReader.InteractListeners;

        //A wrapper for storing the frame input
        private InputWrapper _frameInput;

        private void Awake()
        {
            //Animator = GetComponent<Animator>();
            _movingObject = GetComponent<MovingObject>();

            _state = IdleState;
            _state.OnEnter(this);

            _inputReader = new PlayerInput();
        }

        private void Update()
        {
            _frameInput = _inputReader.GetInput();
            
            var newState = State.Update(this, _frameInput);
            if (newState != null)
                State = newState;

            //Animator.SetFloat("moveX", _frameInput.direction.x);
            //Animator.SetFloat("moveY", _frameInput.direction.y);
        }

        public void Move(Vector2 velocity)
        {
            _movingObject.velocity = velocity;
        }
    }
}