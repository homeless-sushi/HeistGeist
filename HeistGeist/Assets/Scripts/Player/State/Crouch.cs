using UnityEngine;

namespace Player.State
{
    public class Crouch : IState
    {
        public Value Value => Value.Crouch;
        
        public void OnEnter(PlayerController playerController)
        {
            playerController.Animator.SetTrigger("Crouch_trig");
        }
        
        public IState Update(PlayerController playerController)
        {
            if (!playerController.PlayerInput.Crouch)
                if (playerController.PlayerInput.Direction == Vector2.zero)
                {
                    return PlayerController.IdleState;
                }
                else
                {
                    return PlayerController.WalkState;
                }
            
            playerController.Move(playerController.PlayerInput.Direction * playerController.crouchSpeed);
            return null;
        }

        public void OnExit(PlayerController playerController) { }
    }
}