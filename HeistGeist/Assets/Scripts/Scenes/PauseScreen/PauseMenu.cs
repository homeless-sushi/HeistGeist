using System;
using Manager;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Scene = Scenes.Scene;

namespace Scenes.PauseScreen
{
    public class PauseMenu : MonoBehaviour
    {

        [SerializeField] private EventSystem _backupEventSystem;

        private void Awake()
        {
            GameObject eventSystemGameObject = GameObject.Find("EventSystem");
            if(eventSystemGameObject == null)
                _backupEventSystem.gameObject.SetActive(true);
        }

        private void Start()
        {
            GameManager.Instance.SoundManager.SetPauseScreenEffects(true);
        }

        private void OnDestroy()
        {
            GameManager.Instance.SoundManager.SetPauseScreenEffects(false);
        }

        public void Resume()
        {
            GameManager.Instance.GameplayRun();
        }
        
        public void Restart()
        {
            FindObjectOfType<TransitionManager>().TransitionOut(
                "In the sewers below the bank...",
                () => {
                    GameManager.Instance.ResetGameplay();
                    GameManager.Instance.GameplayStop();
                    SceneManager.LoadScene((int) SceneFlow.GetRandomOutsideScene());
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
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#endif

#if UNITY_STANDALONE
            Application.Quit(); 
#endif
        }
    }
}
