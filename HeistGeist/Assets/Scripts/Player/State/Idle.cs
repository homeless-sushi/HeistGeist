using UnityEngine;

namespace Player.State
{
    public class Idle : IState
    {
        public void OnEnter(PlayerController playerController)
        {
            //PlayerController.Animator.SetTrigger("idling");
        }

        public IState HandleInput(PlayerController playerController, InputWrapper inputWrapper)
        {
            if (inputWrapper.crouch)
                return new Crouch();
            
            if (inputWrapper.direction != Vector2.zero)
                return new Walk();
            
            return null;
        }

        public void OnExit(PlayerController playerController) { }
    }
}