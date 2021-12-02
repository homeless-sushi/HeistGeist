using JetBrains.Annotations;

namespace Player.State
{
    public interface IState
    {
        public void OnEnter(PlayerController playerController);
        [CanBeNull] public IState Update(PlayerController playerController);
        public void OnExit(PlayerController playerController);

        public Value Value { get; }
    }

    public enum Value
    {
        Idle = 0,
        Walk = 1,
        Crouch = 2,
        Slide = 3,
    }
}