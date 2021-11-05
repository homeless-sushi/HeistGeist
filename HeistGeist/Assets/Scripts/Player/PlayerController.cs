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

        public PlayerInput PlayerInput { get; private set; }
        public UnityEvent InteractEvent { get; private set; }

        private void Awake()
        {
            Animator = GetComponent<Animator>();
            _movingObject = GetComponent<MovingObject>();

            _state = IdleState;
            _state.OnEnter(this);

            PlayerInput = new PlayerInput();
            InteractEvent = new UnityEvent();
        }

        private void Update()
        {
            var newState = State.Update(this);
            if (newState != null)
                State = newState;

            if(PlayerInput.Interact)
                InteractEvent.Invoke();

            if (PlayerInput.Direction != Vector2.zero)
            {
                Animator.SetFloat("MoveX_f", PlayerInput.Direction.x);
                Animator.SetFloat("MoveY_f", PlayerInput.Direction.y);
            }
        }

        public void Move(Vector2 velocity)
        {
            _movingObject.velocity = velocity;
        }
    }
}