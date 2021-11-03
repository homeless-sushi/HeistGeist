using UnityEngine;

namespace Player.State
{
    public class Walk : IState
    {
        private float velocity = 10f;

        public void OnEnter(PlayerController playerController)
        {
            //PlayerController.Animator.SetTrigger("walking");
        }

        public IState HandleInput(PlayerController playerController, InputWrapper inputWrapper)
        {
            if (inputWrapper.direction == Vector2.zero)
                return new Idle();

            if (inputWrapper.crouch)
                return new Slide();

            playerController.Move(inputWrapper.direction, velocity);
            return null;
        }

        public void OnExit(PlayerController playerController) { }
    }
}