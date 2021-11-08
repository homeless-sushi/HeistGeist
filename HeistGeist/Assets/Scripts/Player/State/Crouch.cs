using UnityEngine;

namespace Player.State
{
    public class Crouch : IState
    {
        private const float Speed = 3f;
        
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
            
            playerController.Move(playerController.PlayerInput.Direction * Speed);
            return null;
        }

        public void OnExit(PlayerController playerController) { }
    }
}