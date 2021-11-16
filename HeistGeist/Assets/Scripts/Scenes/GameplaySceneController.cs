using Manager;
using UnityEngine;

namespace Scenes
{
    public abstract class GameplaySceneController : MonoBehaviour
    {
        [SerializeField] protected GameManager gameManager;
        
        protected abstract void Generate();
        
        public void Fail(bool restartScene)
        {
            gameManager.AddStrike();
            if (restartScene)
            {
                gameManager.RestartScene();
            }
        }
    }
}
