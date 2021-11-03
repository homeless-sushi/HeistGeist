﻿using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    [RequireComponent(typeof(Animator))]
    public class PlayerController : MovingObject
    {
        public static readonly State.IState IdleState = new State.Idle();
        public static readonly State.IState WalkState = new State.Walk();
        public static readonly State.IState SlideState = new State.Slide();
        public static readonly State.IState CrouchState = new State.Crouch();
        //The player character's animator
        public Animator Animator { get; private set; }

        //The player character's state
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

        protected override void Awake()
        {
            base.Awake();

            //Animator = GetComponent<Animator>();

            _state = IdleState;
            _state.OnEnter(this);

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
            var newState = State.HandleInput(this, _frameInput);
            if (newState != null)
                State = newState;
        }

        //protected override RaycastHit2D CanMove(Vector3 end)
        //   return new RaycastHit2D();
        //}

        //protected override void OnCantMove(RaycastHit2D hit, Vector2 target)
        //{
        //}
    }
}