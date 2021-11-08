using UnityEngine;

namespace Manager
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private int maxStrikes;
        [SerializeField] private int currStrikes;
        
        public void AddStrike()
        {
            currStrikes++;
            if (currStrikes >= maxStrikes)
            {
                GameOver();
            }
        }

        public void RestartScene()
        {
        }

        private void GameOver()
        {
        }
    }
}