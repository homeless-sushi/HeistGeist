using Scenes;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = Scenes.Scene;

namespace Manager
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private int maxStrikes;
        public int MaxStrikes { get; private set; }
        [SerializeField] private int currStrikes;
        public int CurrStrikes { get; private set; }

        private Timer _timer;
        
        protected override void Awake()
        {
            base.Awake();
        }

        protected void Start()
        {
            _timer = GetComponent<Timer>();
            _timer.expired.AddListener(GameOver);
        }
        
        public void AddStrike()
                 {
                     currStrikes++;
                     if (currStrikes >= maxStrikes)
                     {
                         GameOver();
                     }
                 }

        public void GameplayStart()
        {
            _timer.isRunning = true;
            currStrikes = maxStrikes;
        }

        public void GameplayEnd()
        {
            _timer.isRunning = false;
        }

        private void GameOver()
        {
            GameplayEnd();
            SceneManager.LoadScene((int) Scene.RestartScene);
        }
    }
}