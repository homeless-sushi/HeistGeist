using Scenes;
using System;
using Manager.UI;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = Scenes.Scene;

namespace Manager
{
    public class GameManager : Singleton<GameManager>
    {
        private bool _isGameplayOn = false;
        public bool IsGameplayOn => _isGameplayOn;

        [SerializeField] private int maxStrikes;
        [SerializeField] private int currStrikes;
        public int MaxStrikes => maxStrikes;
        public int CurrStrikes => currStrikes;

        [Header("UI")]
        [SerializeField] private TimerStrikesUI timerStrikesUI;

        private Timer _timer;
        
        private PauseManager _pauseManager;
        public PauseManager PauseManager => _pauseManager;

        private SoundManager _soundManager;
        public SoundManager SoundManager => _soundManager;
        protected override void Awake()
        {
            base.Awake();
            
            _timer = GetComponent<Timer>();
            _pauseManager = GetComponent<PauseManager>();
            _soundManager = GetComponent<SoundManager>();
        }

        protected void Start()
        {
            _timer.expired.AddListener(GameOver);
            
            timerStrikesUI.SetTime(_timer.GetRemainingTime());
            timerStrikesUI.SetStrikes(currStrikes);
        }

        private void Update()
        {
            timerStrikesUI.SetTime(_timer.GetRemainingTime());
        }
        
        public void AddStrike()
        {
            currStrikes++;
            timerStrikesUI.SetStrikes(currStrikes);
            if (currStrikes >= maxStrikes)
            {
                GameOver();
            }
        }

        public void GameplayStart()
        {
            _isGameplayOn = true;
            
            _timer.isRunning = true;
            currStrikes = 0;
            timerStrikesUI.SetStrikes(0);

            timerStrikesUI.gameObject.SetActive(true);
        }

        public void GameplayEnd()
        {
            _isGameplayOn = false;
            
            _timer.isRunning = false;
            _timer.Reset();
            
            timerStrikesUI.gameObject.SetActive(false);
        }

        private void GameOver()
        {
            GameplayEnd();
            SceneManager.LoadScene((int) Scene.RestartScreen);
        }
    }
}