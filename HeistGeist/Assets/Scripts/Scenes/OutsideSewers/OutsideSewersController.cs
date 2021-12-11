
using UnityEngine;

namespace Scenes.OutsideSewers
{
    public class OutsideSewersController : GameplaySceneController
    {
        [SerializeField]
        private Room[] rooms;
        [SerializeField]
        private TunnelSpriteData tunnelSpriteData;

        private void Start()
        {
            Generate();
        }

        protected override void Generate()
        {
            rooms[0].Teleport();
            print("Start");
        }
    }
}
