using System;
using Manager;
using UnityEngine;

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
                GameManager.Instance.RestartScene();
            }
        }
    }
}
