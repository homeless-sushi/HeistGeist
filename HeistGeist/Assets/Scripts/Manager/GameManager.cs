using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = Scenes.Scene;

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
        
        protected override void Awake()
        {
            base.Awake();
        }

        protected void Start()
        {
            _timer = GetComponent<Timer>();
            _timer.expired.AddListener(GameOver);
        }

        public static void RestartScene()
        {
            LoadNextScene(SceneManager.GetActiveScene().buildIndex);
        }

        public static void LoadNextScene(int scene)
        {
            SceneManager.LoadScene(scene);
        }
        
        public static void LoadNextScene(Scene scene)
        {
            SceneManager.LoadScene((int)scene);
        }

        private static void GameOver()
        {
        }
    }
}