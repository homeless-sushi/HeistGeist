using UnityEngine;

namespace Player.State
{
        public class SlideState : IState
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

            public SlideState()
            {
                _frictionDeceleration = InitialVelocity / SlideDuration;
            }

            public void OnEnter(PlayerController playerController)
            {
                //PlayerController.Animator.SetTrigger("sliding");
                _speed = InitialVelocity;
                _transitionOutTimeLeft = TransitionOutTime;

            }

            public IState HandleInput(PlayerController playerController, InputWrapper inputWrapper)
            {
                if (!inputWrapper.crouch)
                    if (inputWrapper.direction == Vector2.zero)
                    {
                        return new IdleState();
                    }
                    else
                    {
                        return new WalkState();
                    }
                
                playerController.Move(inputWrapper.direction, _speed);
                _speed -= _frictionDeceleration * Time.fixedDeltaTime;
                _speed = Mathf.Max(0, _speed);
                
                if (_speed == 0)
                {
                    _transitionOutTimeLeft -= Time.fixedDeltaTime;
                }
                return (_transitionOutTimeLeft > 0) ? null : new CrouchState();
            }

            public void OnExit(PlayerController playerController){ }
        }
}
