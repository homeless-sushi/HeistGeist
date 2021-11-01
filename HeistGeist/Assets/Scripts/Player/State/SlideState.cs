using JetBrains.Annotations;
using UnityEngine;
using Player;
using Player.State;

namespace Player.State
{
        public class SlideState : PlayerState
        {
            //TODO: Use the real formula for sliding deceleration
            //slide initial params
            private const float InitialVelocity = 15f;  //initial velocity of the slide
            private const float SlideDuration = .4f; //how long should the slide last
            private const float TransitionOutTime = .3f; //how long should the player stay still before crouching
            //slide inferred params
            private readonly float _frictionDeceleration;
            //slide variables
            private float _transitionOutTimeLeft; //how long until transitioning to crouch
            private float _speed; //curr velocity

            public SlideState(PlayerController playerController) : base(playerController)
            {
                _frictionDeceleration = InitialVelocity / SlideDuration;
            }

            public override void OnEnter()
            {
                //PlayerController.Animator.SetTrigger("sliding");
                _speed = InitialVelocity;
                _transitionOutTimeLeft = TransitionOutTime;

            }

            public override PlayerState HandleInput(InputWrapper inputWrapper)
            {
                if (!inputWrapper.crouch)
                    if (inputWrapper.direction == Vector2.zero)
                    {
                        return new IdleState(PlayerController);
                    }
                    else
                    {
                        return new WalkState(PlayerController);
                    }
                
                PlayerController.Move(inputWrapper.direction, _speed);
                _speed -= _frictionDeceleration * Time.fixedDeltaTime;
                _speed = Mathf.Max(0, _speed);
                
                if (_speed == 0)
                {
                    _transitionOutTimeLeft -= Time.fixedDeltaTime;
                }
                return (_transitionOutTimeLeft > 0) ? null : new CrouchState(PlayerController);
            }

            public override void OnExit(){ }
        }
}
