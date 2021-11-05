using UnityEngine;

namespace Player.State
{
    public class Walk : IState
    {
        private const float Speed = 10f;

        public void OnEnter(PlayerController playerController)
        {
            playerController.Animator.SetTrigger("Walk_trig");
        }

        public IState Update(PlayerController playerController)
        {
            if (playerController.PlayerInput.Direction == Vector2.zero)
                return PlayerController.IdleState;

            if (playerController.PlayerInput.Crouch)
                return PlayerController.SlideState;

            playerController.Move(playerController.PlayerInput.Direction * Speed);
            return null;
        }

        public void OnExit(PlayerController playerController) { }
    }
}