using UnityEngine;

namespace Manager
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private int maxStrikes;
        [SerializeField] private int currStrikes;

        private Timer _timer;
        
        public void AddStrike()
        {
            currStrikes++;
            if (currStrikes >= maxStrikes)
            {
                GameOver();
            }
        }
        
        protected void Start()
        {
            _timer = GetComponent<Timer>();
            _timer.expired.AddListener(GameOver);
        }

        public void RestartScene()
        {
        }

        private void GameOver()
        {
        }
    }
}