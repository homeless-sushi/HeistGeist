using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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

        public int CurrentStage { get; private set; }
        private readonly StageExit[] _history = new StageExit[StagesCount - 1];
        
        private void Start()
        {
            CurrentStage = 0;
            _tunnelTypes = Enumerable.Range(0, tunnelSprites.Length).ToArray();
            Generate();
        }

        protected override void Generate()
        {
            print("Start");
            _history[CurrentStage] = StageSelector.LoadRandomStage(this);
            CurrentStage++;
        }

        public IEnumerable<int> TunnelTypeSample(int k)
        {
            return Utils.Sample(_tunnelTypes, k);
        }

        public Room LoadRandomRoom(int numTunnels)
        {
            var room = rooms.GetRandomRoom(numTunnels);
            room.Teleport();
            return room;
        }

        public StageExit GetStageExit(int stage)
        {
            return _history[stage];
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
