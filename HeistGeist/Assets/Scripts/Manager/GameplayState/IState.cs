using JetBrains.Annotations;

namespace Manager.GameplayState
{
    public interface IState
    {
        public void OnEnter(GameManager gameManager);
        [CanBeNull] public IState Update(GameManager gameManager);
        public void OnExit(GameManager gameManager);
        
        public Value Value { get; }
    }
    
    public enum Value
    {
        Run = 0,
        Stop = 1,
        Pause = 2
    }
}