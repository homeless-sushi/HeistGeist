using Manager;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Scenes.StartScreen
{
    public class LoadLevelButton : MonoBehaviour
    {
        private Button _button;
        [SerializeField] private string introText;
        [SerializeField] private Scene level;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(LoadPracticeLevel);
        }

        private void LoadPracticeLevel()
        {
            GameManager.Instance.GameModeData = new GameModeData(GameModeData.GameMode.Practice);
            GameManager.Instance.GameModeData.RestartText = introText;
            GameManager.Instance.GameModeData.RestartScene = level;
            
            FindObjectOfType<TransitionManager>().TransitionOut(
                GameManager.Instance.GameModeData.RestartText,
                () =>
                {
                    GameManager.Instance.ResetGameplay();
                    SceneManager.LoadScene((int) GameManager.Instance.GameModeData.RestartScene);
                });
        }
    }
}
