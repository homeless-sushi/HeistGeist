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
            FindObjectOfType<TransitionManager>().TransitionOut(null,
                () =>
                {
                    SceneManager.LoadScene((int) SceneFlow.GetRandomOutsideScene());
                    GameManager.Instance.GameplayStart();
                });
        }

        public void GoToMainMenu()
        {
            FindObjectOfType<TransitionManager>().QuitTransition(
                () => 
                {
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
