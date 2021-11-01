using JetBrains.Annotations;
using UnityEngine;

namespace Player.State
{
    public class CrouchState : PlayerState
    {
        private const float Velocity = 3f;

        public CrouchState(PlayerController playerController) : base(playerController){ }

        public override void OnEnter()
        {
            //PlayerController.Animator.SetTrigger("crouching");
        }
        
        public override PlayerState HandleInput(InputWrapper inputWrapper)
        {
            if (!inputWrapper.crouch)
                if (inputWrapper.direction == Vector2.zero)
                {
                    return new IdleState(PlayerController);
                }
                else
                {
                    return new WalkState(PlayerController);
                }
            
            PlayerController.Move(inputWrapper.direction, Velocity);
            return null;
        }

        public override void OnExit() { }
    }
}