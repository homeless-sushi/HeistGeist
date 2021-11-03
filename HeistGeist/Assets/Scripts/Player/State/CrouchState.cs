using UnityEngine;

namespace Player.State
{
    public class CrouchState : IState
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
                    return new IdleState();
                }
                else
                {
                    return new WalkState();
                }
            
            playerController.Move(inputWrapper.direction, Velocity);
            return null;
        }

        public void OnExit(PlayerController playerController) { }
    }
}