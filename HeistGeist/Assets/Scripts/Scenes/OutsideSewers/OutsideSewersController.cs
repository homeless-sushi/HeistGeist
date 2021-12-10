using Teleport;
using UnityEngine;

namespace Scenes.OutsideSewers
{
    public class OutsideSewersController : GameplaySceneController
    {
        [SerializeField]
        private Teleporter startPosition;

        private void Start()
        {
            Generate();
        }

        protected override void Generate()
        {
            startPosition.Teleport();
        }
    }
}
