using Scenes;
using System;
using Manager.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = Scenes.Scene;

namespace Manager
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private int maxStrikes;
        [SerializeField] private int currStrikes;
        public int MaxStrikes => maxStrikes;
        public int CurrStrikes => currStrikes;

        [Header("UI")]
        [SerializeField] private TimerStrikesUI timerStrikesUI;

        private Timer _timer;
                
        protected override void Awake()
        {
            base.Awake();
        }

        protected void Start()
        {
            _timer = GetComponent<Timer>();
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
            _timer.isRunning = true;
            currStrikes = 0;

            timerStrikesUI.gameObject.SetActive(true);
        }

        public void GameplayEnd()
        {
            _timer.isRunning = false;
            
            timerStrikesUI.gameObject.SetActive(false);
        }

        private void GameOver()
        {
            GameplayEnd();
            SceneManager.LoadScene((int) Scene.RestartScreen);
        }
    }
}