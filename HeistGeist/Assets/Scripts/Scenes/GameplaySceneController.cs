using System;
using Manager;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes
{
    public abstract class GameplaySceneController : MonoBehaviour
    {
        protected abstract void Generate();

        public void Fail(bool restartScene)
        {
            bool gameOver = GameManager.Instance.AddStrike();
            if (!gameOver && restartScene)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
