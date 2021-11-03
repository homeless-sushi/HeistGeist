using JetBrains.Annotations;

namespace Player.State
{
    public interface IState
    {
        public void OnEnter(PlayerController playerController);
        [CanBeNull] public IState Update(PlayerController playerController);
        public void OnExit(PlayerController playerController);
    }
}