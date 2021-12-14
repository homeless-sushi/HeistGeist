using System;
using Manager;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes.StartScreen
{
    public class MainMenu : MonoBehaviour
    {
        void Start()
        {
            FindObjectOfType<TransitionManager>().StartTransition(null);
        }
        
        
        public void PlayGame()
        {
            FindObjectOfType<TransitionManager>().TransitionOut("Inside the Bank",
                () =>
                {
                    SceneManager.LoadScene((int) SceneFlow.GetRandomOutsideScene());
                    GameManager.Instance.GameplayStart();
                });
        }
        
        public void QuitGame()
        {
            FindObjectOfType<TransitionManager>().QuitTransition(
                ()=>
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

