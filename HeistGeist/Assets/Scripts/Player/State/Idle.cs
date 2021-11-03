using UnityEngine;

namespace Player.State
{
    public class Idle : IState
    {
        public void OnEnter(PlayerController playerController)
        {
            //PlayerController.Animator.SetTrigger("idling");
            playerController.Move(Vector2.zero);
        }

        public IState Update(PlayerController playerController, InputWrapper inputWrapper)
        {
            if (inputWrapper.crouch)
                return PlayerController.CrouchState;
            
            if (inputWrapper.direction != Vector2.zero)
                return PlayerController.WalkState;
            
            return null;
        }

        public void OnExit(PlayerController playerController) { }
    }
}