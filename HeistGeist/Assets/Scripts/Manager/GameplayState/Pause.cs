using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = Scenes.Scene;

namespace Manager.GameplayState
{
    //TimeScale = 0
    //Timer running
    //Interface active
    //Can be paused with ESC
    public class Pause : IState
    {
        public Value Value => Value.Pause;
        
        public void OnEnter(GameManager gameManager)
        {
            gameManager.TimerStrikes.TimerStrikesUI.gameObject.SetActive(true);
            Time.timeScale = 0f;
            
            SceneManager.LoadScene((int)Scene.PauseScreen, LoadSceneMode.Additive);
        }

        public IState Update(GameManager gameManager)
        {
            gameManager.TimerStrikes.UpdateTimer(Time.unscaledDeltaTime);
            
            return Input.GetKeyDown(KeyCode.Escape) ? GameManager.RunState : null;
        }

        public void OnExit(GameManager gameManager)
        {
            SceneManager.UnloadSceneAsync((int) Scene.PauseScreen);
        }
    }
}