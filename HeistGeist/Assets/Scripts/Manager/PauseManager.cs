using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = Scenes.Scene;

namespace Manager
{
    public class PauseManager : MonoBehaviour
    {
        private bool _isPaused = false;
        private void Update()
        {
            if (!GameManager.Instance.IsGameplayOn)
                return;
            
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (_isPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }

        public void Resume()
        {
            AsyncOperation unloadOperation = SceneManager.UnloadSceneAsync((int) Scene.PauseScreen);
            unloadOperation.completed += (AsyncOperation asyncOperation) =>
            {
                Time.timeScale = 1f;
                _isPaused = false;
            };
        }
        
        public void Pause()
        {
            _isPaused = true;
            SceneManager.LoadScene((int)Scene.PauseScreen, LoadSceneMode.Additive);

            Time.timeScale = 0;
        }
    }
}