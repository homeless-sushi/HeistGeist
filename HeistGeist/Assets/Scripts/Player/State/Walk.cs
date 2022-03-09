using UnityEngine;

namespace Player.State
{
    public class Walk : IState
    {
        public Value Value => Value.Walk;
        
        public void OnEnter(PlayerController playerController)
        {
            playerController.Animator.SetTrigger("Walk_trig");
        }

        public IState Update(PlayerController playerController)
        {
            if (playerController.PlayerInput.Direction == Vector2.zero)
                return PlayerController.IdleState;

            if (playerController.PlayerInput.Crouch && playerController.canSlide)
                return PlayerController.SlideState;

            playerController.Move(playerController.PlayerInput.Direction * playerController.walkSpeed);
            return null;
        }

        public void OnExit(PlayerController playerController) { }
    }
}