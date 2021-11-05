using UnityEngine;

namespace Player.State
{
    public class Idle : IState
    {
        public void OnEnter(PlayerController playerController)
        {
            playerController.Animator.SetTrigger("Idle_trig");
            playerController.Move(Vector2.zero);
        }

        public IState Update(PlayerController playerController)
        {
            if (playerController.PlayerInput.Crouch)
                return PlayerController.CrouchState;
            
            if (playerController.PlayerInput.Direction != Vector2.zero)
                return PlayerController.WalkState;
            
            return null;
        }

        public void OnExit(PlayerController playerController) { }
    }
}