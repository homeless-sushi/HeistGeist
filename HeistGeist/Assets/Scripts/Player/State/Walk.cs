using UnityEngine;

namespace Player.State
{
    public class Walk : IState
    {
        private const float Velocity = 10f;

        public void OnEnter(PlayerController playerController)
        {
            //PlayerController.Animator.SetTrigger("walking");
        }

        public IState HandleInput(PlayerController playerController, InputWrapper inputWrapper)
        {
            if (inputWrapper.direction == Vector2.zero)
                return PlayerController.IdleState;

            if (inputWrapper.crouch)
                return PlayerController.SlideState;

            playerController.Move(inputWrapper.direction, Velocity);
            return null;
        }

        public void OnExit(PlayerController playerController) { }
    }
}