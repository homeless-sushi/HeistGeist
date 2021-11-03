using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    [RequireComponent(typeof(Animator))]
    public class PlayerController : MovingObject
    {
        //The player character's animator
        public Animator Animator { get; private set; }

        //The player character's state
        public State.IState State { get; private set; }

        //A class for reading input
        private PlayerInput _inputReader;
        public UnityEvent InteractEvent => _inputReader.InteractListeners;

        //A wrapper for storing the frame input
        private InputWrapper _frameInput;

        protected override void Awake()
        {
            base.Awake();

            //Animator = GetComponent<Animator>();

            State = new State.IdleState();
            State.OnEnter(this);

            _inputReader = new PlayerInput();
        }

        private void Update()
        {
            _frameInput = _inputReader.GetInput();

            //Animator.SetFloat("moveX", _frameInput.direction.x);
            //Animator.SetFloat("moveY", _frameInput.direction.y);
        }

        private void FixedUpdate()
        {
            State.IState newState =
                State.HandleInput(this, _frameInput);
            if (newState != null)
            {
                ChangeState(newState);
            }
        }

        //protected override RaycastHit2D CanMove(Vector3 end)
        //   return new RaycastHit2D();
        //}

        //protected override void OnCantMove(RaycastHit2D hit, Vector2 target)
        //{
        //}

        private void ChangeState(State.IState newState)
        {
            State.OnExit(this);
            State = newState;
            State.OnEnter(this);
        }
    }
}