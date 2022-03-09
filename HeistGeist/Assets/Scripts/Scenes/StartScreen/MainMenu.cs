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
            GameManager.Instance.GameModeData = new GameModeData(GameModeData.GameMode.Story);
            GameManager.Instance.GameModeData.RestartText = "The night of the heist";
            GameManager.Instance.GameModeData.RestartScene = Scene.OutsideStreet;
            
            FindObjectOfType<TransitionManager>().TransitionOut(
                GameManager.Instance.GameModeData.RestartText,
                () =>
                {
                    GameManager.Instance.ResetGameplay();
                    SceneManager.LoadScene((int) GameManager.Instance.GameModeData.RestartScene);
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

