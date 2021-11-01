using JetBrains.Annotations;

namespace Player.State
{
    public abstract class PlayerState
    {
        protected readonly PlayerController PlayerController;

        protected PlayerState(PlayerController playerController)
        {
            PlayerController = playerController;
        }

        public abstract void OnEnter();
        [CanBeNull] public abstract PlayerState HandleInput(InputWrapper inputWrapper);
        //[CanBeNull] public abstract PlayerState Update();
        public abstract void OnExit();
    }
}