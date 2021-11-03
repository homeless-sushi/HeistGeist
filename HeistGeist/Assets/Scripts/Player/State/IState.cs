using JetBrains.Annotations;

namespace Player.State
{
    public interface IState
    {
        public void OnEnter(PlayerController playerController);
        [CanBeNull] public IState HandleInput(PlayerController playerController, InputWrapper inputWrapper);
        //[CanBeNull] public PlayerState Update();
        public void OnExit(PlayerController playerController);
    }
}