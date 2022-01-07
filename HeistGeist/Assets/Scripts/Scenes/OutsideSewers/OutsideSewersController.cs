using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes.OutsideSewers
{
    public class OutsideSewersController : GameplaySceneController
    {
        private const int StagesCount = 4;
        
        [SerializeField]
        private Rooms rooms;
        [SerializeField]
        public Sprite[] tunnelSprites;

        private int[] _tunnelTypes;

        public int currentStage;
        [SerializeField]
        private StageExit[] history = new StageExit[StagesCount];
        
        private void Start()
        {
            _tunnelTypes = Enumerable.Range(0, tunnelSprites.Length).ToArray();
            Generate();
        }

        protected override void Generate()
        {
            LoadNextStage();
        }

        public void LoadNextStage()
        {
            if (currentStage >= StagesCount)
            {
                SceneManager.LoadScene((int) SceneFlow.GetRandomBankScene());
                return;
            }
            
            history[currentStage] = StageSelector.LoadRandomStage(this);
            currentStage++;
        }

        public void WrongTunnel()
        {
            Fail(true);
        }

        public IEnumerable<int> TunnelTypeSample(int k)
        {
            return Utils.Sample(_tunnelTypes, k < StagesCount ? k : StagesCount);
        }

        public Room LoadRandomRoom(int numTunnels)
        {
            var room = rooms.GetRandomRoom(numTunnels);
            room.Teleport();
            return room;
        }

        public StageExit GetStageExit(int stage)
        {
            return history[stage];
        }
    }

    public enum TunnelType
    {
        Normal = 0,
        Wet = 1,
        Mossy = 2,
        Muddy = 3,
    }
    
    public enum TunnelPosition
    {
        Left = 0,
        Center = 1,
        Right = 2,
        FarRight = 3,
    }
}
