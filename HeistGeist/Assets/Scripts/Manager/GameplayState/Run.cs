using JetBrains.Annotations;
using UnityEngine;

namespace Manager.GameplayState
{
    //TimeScale = 1
    //Timer running
    //Interface active
    //Can be resumed with ESC
    public class Run : IState
    {
        public Value Value => Value.Run;
        
        public void OnEnter(GameManager gameManager)
        {
            gameManager.TimerStrikes.TimerStrikesUI.gameObject.SetActive(true);
            Time.timeScale = 1f;
        }

        [CanBeNull]
        public IState Update(GameManager gameManager)
        {
            gameManager.TimerStrikes.UpdateTimer(Time.unscaledDeltaTime);
            
            return Input.GetKeyDown(KeyCode.Escape) ? GameManager.PauseState : null;
        }

        public void OnExit(GameManager gameManager)
        {
        }
    }
}