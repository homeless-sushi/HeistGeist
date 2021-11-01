using JetBrains.Annotations;
using UnityEngine;
using Player;

namespace Player.State
{
    public class WalkState : PlayerState
    {
        private float velocity = 10f;

        public WalkState(PlayerController playerController) : base(playerController){ }

        public override void OnEnter()
        {
            //PlayerController.Animator.SetTrigger("walking");
        }

        public override PlayerState HandleInput(InputWrapper inputWrapper)
        {
            if (inputWrapper.direction == Vector2.zero)
                return new IdleState(PlayerController);

            if (inputWrapper.crouch)
                return new SlideState(PlayerController);

            PlayerController.Move(inputWrapper.direction, velocity);
            return null;
        }

        public override void OnExit() { }
    }
}