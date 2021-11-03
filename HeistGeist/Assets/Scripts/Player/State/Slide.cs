using UnityEngine;

namespace Player.State
{
        public class Slide : IState
        {
            //TODO: Use the real formula for sliding deceleration
            //slide initial params
            private const float InitialSpeed = 15f;  //initial velocity of the slide
            private const float SlideDuration = .4f; //how long should the slide last
            private const float TransitionOutTime = .3f; //how long should the player stay still before crouching
            //slide inferred params
            private const float FrictionDeceleration = InitialSpeed / SlideDuration;
            //slide variables
            private float _transitionOutTimeLeft; //how long until transitioning to crouch
            private float _speed; //curr velocity

            public void OnEnter(PlayerController playerController)
            {
                //PlayerController.Animator.SetTrigger("sliding");
                _speed = InitialSpeed;
                _transitionOutTimeLeft = TransitionOutTime;
            }

            public IState Update(PlayerController playerController)
            {
                if (!playerController.PlayerInput.Crouch)
                    if (playerController.PlayerInput.Direction == Vector2.zero)
                    {
                        return PlayerController.IdleState;
                    }
                    else
                    {
                        return PlayerController.WalkState;
                    }
                
                playerController.Move(playerController.PlayerInput.Direction * _speed);
                _speed -= FrictionDeceleration * Time.deltaTime;
                _speed = Mathf.Max(0, _speed);
                
                if (_speed == 0)
                {
                    _transitionOutTimeLeft -= Time.deltaTime;
                }
                return (_transitionOutTimeLeft > 0) ? null : PlayerController.CrouchState;
            }

            public void OnExit(PlayerController playerController){ }
        }
}
