using Manager;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes.StartScreen
{
    public class MainMenu : MonoBehaviour
    {
        public void PlayGame()
        {
            SceneManager.LoadScene((int) SceneFlow.GetRandomOutsideScene());
            GameManager.Instance.GameplayStart();
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

