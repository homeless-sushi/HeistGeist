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
            GameManager.Instance.AddStrike();
            if (restartScene)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
