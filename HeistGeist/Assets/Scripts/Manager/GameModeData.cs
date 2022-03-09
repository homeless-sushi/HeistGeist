using System;
using Scenes;

namespace Manager
{
    [Serializable] public class GameModeData
    {
        public enum GameMode
        {
            Story,
            Practice
        }
        public GameModeData(GameMode gameMode){
            CurrentGameMode = gameMode;
            switch (gameMode)
            {
                case GameMode.Story:
                    _maxSeconds = 720;
                    break;
                
                case GameMode.Practice:
                    _maxSeconds = 300;
                    break;
            }
        }
        
        public GameMode CurrentGameMode { get; set; }

        private float _maxSeconds;
        public float MaxSeconds
        {
            get => _maxSeconds;
        }
        public Scene RestartScene { get; set; }
        public string RestartText { get; set; }
    }
}