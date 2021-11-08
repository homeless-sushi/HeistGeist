using UnityEngine;
using UnityEngine.SceneManagement;

namespace Manager
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private int maxStrikes;
        [SerializeField] private int currStrikes;

        private Timer _timer;
        private SceneFlow _sceneFlow;
        
        public void AddStrike()
        {
            currStrikes++;
            if (currStrikes >= maxStrikes)
            {
                GameOver();
            }
        }
        
        protected override void Awake()
        {
            base.Awake();
            
            _sceneFlow = new SceneFlow(SceneManager.GetActiveScene().buildIndex);
        }

        protected void Start()
        {
            _timer = GetComponent<Timer>();
            _timer.expired.AddListener(GameOver);
        }

        public void RestartScene()
        {
            _sceneFlow.RestartScene();
        }

        private void GameOver()
        {
            _sceneFlow.GameOver();
        }
    }
}