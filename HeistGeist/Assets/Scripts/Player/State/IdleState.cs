using UnityEngine;

namespace Player.State
{
    public class IdleState : PlayerState
    {
        public IdleState(PlayerController playerController) : base(playerController){ }

        public override void OnEnter()
        {
            //PlayerController.Animator.SetTrigger("idling");
        }

        public override PlayerState HandleInput(InputWrapper inputWrapper)
        {
            if (inputWrapper.crouch)
                return new CrouchState(PlayerController);
            
            if (inputWrapper.direction != Vector2.zero)
                return new WalkState(PlayerController);
            
            return null;
        }

        public override void OnExit() { }
    }
}