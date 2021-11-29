using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes.RestartScreen
{
    public class RestartMenu : MonoBehaviour
    {
        public void Restart()
        {
        }

        public void GoToMainMenu()
        {
            SceneManager.LoadScene((int) Scene.StartScreen);
        }

        public void QuitGame()
        {
            #if UNITY_EDITOR
                        EditorApplication.ExitPlaymode();
            #endif

            #if UNITY_STANDALONE
                        Application.Quit(); 
            #endif
        }
    }
}
