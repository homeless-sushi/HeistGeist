using JetBrains.Annotations;
using UnityEngine;

namespace Manager.GameplayState
{
    //TimeScale = 1
    //Timer not running
    //Interface not active
    //ESC does nothing
    public class Stop : IState
    {
        public Value Value => Value.Stop;
        
        public void OnEnter(GameManager gameManager)
        {
            gameManager.TimerStrikes.TimerStrikesUI.gameObject.SetActive(false);
            Time.timeScale = 1f;
        }

        [CanBeNull]
        public IState Update(GameManager gameManager)
        {
            return null;
        }

        public void OnExit(GameManager gameManager)
        {
        }
    }
}