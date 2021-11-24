using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes.StartMenu
{
    public class MainMenu : MonoBehaviour
    {
        public void PlayGame ()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    
        public void QuitGame ()
        {
            Debug.Log ("Quit the game");
            Application.Quit();
        }
    }
}

