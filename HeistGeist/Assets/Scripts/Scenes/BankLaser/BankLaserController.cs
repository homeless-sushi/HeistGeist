using System.Collections.Generic;
using UnityEngine;

namespace Scenes.BankLaser
{
    public class BankLaserController : GameplaySceneController
    {
        [Space(20)]
        [Header("Lasers")]
        [SerializeField]
        private GameObject laserPrefab;
        [SerializeField]
        private Vector2[] lasersPositions;
        [SerializeField]
        private int lasersCount;

        [Space(20)]
        [Header("Flags")]
        [SerializeField]
        private FlagGenerator flagGenerator;
        [SerializeField]
        private FlagsChecker flagsChecker;
        
        private void Start()
        {
            Generate();
        }

        protected override void Generate()
        {
            foreach (var position in Utils.Sample(lasersPositions, lasersCount))
            {
                Instantiate(laserPrefab, position, Quaternion.identity).GetComponent<Laser>();
            }
        }
    }
}