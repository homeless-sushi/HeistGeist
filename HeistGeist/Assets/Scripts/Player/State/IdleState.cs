using UnityEngine;

namespace Player.State
{
    public class IdleState : IState
    {
        public void OnEnter(PlayerController playerController)
        {
            //PlayerController.Animator.SetTrigger("idling");
        }

        public IState HandleInput(PlayerController playerController, InputWrapper inputWrapper)
        {
            if (inputWrapper.crouch)
                return new CrouchState();
            
            if (inputWrapper.direction != Vector2.zero)
                return new WalkState();
            
            return null;
        }

        public void OnExit(PlayerController playerController) { }
    }
}