using UnityEngine;

namespace Player.State
{
    public class Crouch : IState
    {
        private const float Velocity = 3f;
        
        public void OnEnter(PlayerController playerController)
        {
            //PlayerController.Animator.SetTrigger("crouching");
        }
        
        public IState HandleInput(PlayerController playerController, InputWrapper inputWrapper)
        {
            if (!inputWrapper.crouch)
                if (inputWrapper.direction == Vector2.zero)
                {
                    return new Idle();
                }
                else
                {
                    return new Walk();
                }
            
            playerController.Move(inputWrapper.direction, Velocity);
            return null;
        }

        public void OnExit(PlayerController playerController) { }
    }
}