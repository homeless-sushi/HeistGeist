using UnityEngine.SceneManagement;

namespace Manager
{
    public class SceneFlow
    {
        private int _currentScene;

        public SceneFlow(int currentScene)
        {
            _currentScene = currentScene;
        }

        public void LoadNextScene(){}

        public void RestartScene()
        {
            SceneManager.LoadScene(_currentScene);
        }

        public void GameOver()
        {}
    }
}