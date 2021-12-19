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
            GameManager.Instance.PauseManager.Resume();
        }
        
        public void Restart()
        {
            GameManager.Instance.GameplayEnd();
            GameManager.Instance.PauseManager.Resume();
            SceneManager.LoadScene((int) SceneFlow.GetRandomOutsideScene());
            GameManager.Instance.GameplayStart();
        }

        public void GoToMainMenu()
        {
            GameManager.Instance.PauseManager.Resume();
            GameManager.Instance.GameplayEnd();
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
