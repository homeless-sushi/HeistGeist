using Manager;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes.RestartScreen
{
    public class RestartMenu : MonoBehaviour
    {
        public void Restart()
        {
            FindObjectOfType<TransitionManager>().TransitionOut(
                GameManager.Instance.GameModeData.RestartText,
                () => {
                    GameManager.Instance.ResetGameplay();
                    GameManager.Instance.GameplayStop();
                    SceneManager.LoadScene((int) GameManager.Instance.GameModeData.RestartScene);
                });
        }

        public void GoToMainMenu()
        {
            FindObjectOfType<TransitionManager>().QuitTransition(
                () => 
                {
                    GameManager.Instance.GameplayStop();
                    SceneManager.LoadScene((int) Scene.StartScreen); 
                });
        }

        public void QuitGame()
        {
            FindObjectOfType<TransitionManager>().QuitTransition(
                () =>
                {   
                    #if UNITY_EDITOR
                                    EditorApplication.ExitPlaymode();
                    #endif

                    #if UNITY_STANDALONE
                                    Application.Quit(); 
                    #endif
                });
            
        }
    }
}
