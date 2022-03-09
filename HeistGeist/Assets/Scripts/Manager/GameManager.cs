using Manager.GameplayState;
using Manager.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = Scenes.Scene;

namespace Manager
{
    public class GameManager : Singleton<GameManager>
    {
        private GameModeData _gameModeData;
        public GameModeData GameModeData
        {
            get => _gameModeData;
            set
            {
                _gameModeData = value;
                ResetGameplay();
            }
        }
        
        public static readonly IState RunState = new Run();
        public static readonly IState PauseState = new Pause();
        public static readonly IState StopState = new Stop();
        
        private IState _currentState;
        private IState CurrentState {
            get => _currentState;
            set {
                _currentState.OnExit(this);
                _currentState = value;
                _currentState.OnEnter(this);
            }
        }
        
        [SerializeField] private int maxStrikes;

        [SerializeField] private TimerStrikes timerStrikes;
        public TimerStrikes TimerStrikes => timerStrikes;

        [Header("UI")]
        [SerializeField] private TimerStrikesUI timerStrikesUI;

        private SoundManager _soundManager;
        public SoundManager SoundManager => _soundManager;

        protected override void Awake()
        {
            base.Awake();

            timerStrikes = new TimerStrikes();
            timerStrikes.TimerStrikesUI = timerStrikesUI;
            timerStrikes.TimerExpired.AddListener(GameOver);

            _soundManager = GetComponent<SoundManager>();
                
            GameModeData = new GameModeData(GameModeData.GameMode.Practice);
            
            _currentState = StopState;
        }

        public void ResetGameplay()
        {
            timerStrikes.CurrStrikes = 0;
            timerStrikes.SetRemainingSeconds(GameModeData.MaxSeconds);
        }

        public void GameplayRun()
        {
            if (CurrentState.Value == RunState.Value)
                return;

            CurrentState = RunState;
        }
        
        public void GameplayPause()
        {
            if (CurrentState.Value == PauseState.Value)
                return;

            CurrentState = PauseState;
        }
        
        public void GameplayStop()
        {
            if (CurrentState.Value == StopState.Value)
                return;

            CurrentState = StopState;
        }

        private void Update()
        {
            var nextState = CurrentState.Update(this);
            if (nextState != null)
                CurrentState = nextState;
        }
        
        public bool AddStrike()
        {
            timerStrikes.AddStrike();
            
            SoundManager.PlayFX(SoundManager.Fx.Strike);
            
            var gameOver = timerStrikes.CurrStrikes >= maxStrikes;
            if (gameOver)
                GameOver();

            return gameOver;
        }

        private void GameOver()
        {
            SceneManager.LoadScene((int) Scene.YouLoseScreen);
        }
    }
}