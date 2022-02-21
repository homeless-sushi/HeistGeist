using System.Collections;
using UnityEngine;

namespace Player.State
{
        public class Slide : IState
        {
            private const float SlideDuration = .4f; //how long should the slide last
            private const float TransitionOutTime = .3f; //how long should the player stay still before crouching
            private const float Timeout = 1f;
            private float _transitionOutTimeLeft; //how long until transitioning to crouch
            private float _speed;
            private float _friction;
            
            public Value Value => Value.Slide;

            public void OnEnter(PlayerController playerController)
            {
                playerController.Animator.SetTrigger("Slide_trig");
                _transitionOutTimeLeft = TransitionOutTime;
                _speed = playerController.slideSpeed;
                _friction = _speed / SlideDuration;
                playerController.canSlide = false;
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

                if (_speed > 0)
                {
                    _speed = Mathf.Max(0, _speed - _friction * Time.deltaTime);
                    playerController.Move(playerController.PlayerInput.Direction * _speed);
                }
                if (_speed == 0)
                {
                    _transitionOutTimeLeft -= Time.deltaTime;
                }
                return (_transitionOutTimeLeft > 0) ? null : PlayerController.CrouchState;
            }

            public void OnExit(PlayerController playerController)
            {
                playerController.StartCoroutine(Example(playerController));
            }

            private static IEnumerator Example(PlayerController playerController)
            {
                yield return new WaitForSeconds(Timeout);
                playerController.canSlide = true;
            }
        }
}
