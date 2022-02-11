using System.Collections.Generic;
using System.Linq;
using Manager;
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
            FindObjectOfType<TransitionManager>().TransitionIn();
            GameManager.Instance.GameplayRun();
            GameManager.Instance.SoundManager.PlayTrack(SoundManager.Track.GameplayTrack);
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
                FindObjectOfType<TransitionManager>().TransitionOut(
                    "Inside the bank",
                    () => {
                        SceneManager.LoadScene((int) SceneFlow.GetRandomBankScene());;
                    });
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
