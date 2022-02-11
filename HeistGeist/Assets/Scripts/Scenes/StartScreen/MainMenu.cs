using System;
using Manager;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes.StartScreen
{
    public class MainMenu : MonoBehaviour
    {
        private static bool _firstTimeStart = true;
        void Start()
        {
            if (_firstTimeStart)
                _firstTimeStart = false;
            else
            {
                FindObjectOfType<TransitionManager>().StartTransition(null);
            }
        }
        
        
        public void PlayGame()
        {
            FindObjectOfType<TransitionManager>().TransitionOut(
                "In the sewers below the bank...",
                () =>
                {
                    GameManager.Instance.ResetGameplay();
                    SceneManager.LoadScene((int) SceneFlow.GetRandomOutsideScene());
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

