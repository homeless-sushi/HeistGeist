using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Scenes.BankLaser
{
    [Flags]
    internal enum Flags
    {
        LightOn    = 0b_000001,
        LightBlink = 0b_000010,
        RedLaser   = 0b_000100,
        BlueLaser  = 0b_001000,
        ThirdLaser = 0b_010000,
        TowerType  = 0b_100000,
    }
    
    [Serializable]
    internal struct FlagGenerator
    {
        [Header("Probabilities")]
        [SerializeField]
        [Range(0f,1f)]
        private float redLaser;
        [SerializeField]
        [Range(0f,1f)]
        private float blueLaser;
        [SerializeField]
        [Range(0f,1f)]
        private float thirdLaser;
        [SerializeField]
        [Range(0f,1f)]
        private float towerType;
        [SerializeField]
        [Range(0f,1f)]
        private float lightOn;
        [SerializeField]
        [Range(0f,1f)]
        private float lightBlink;

        public Flags GetFlags()
        {
            Flags f = 0;
            if (Random.value < redLaser)
                f |= Flags.RedLaser;
            if (Random.value < blueLaser)
                f |= Flags.BlueLaser;
            if (Random.value < thirdLaser)
                f |= Flags.ThirdLaser;
            if (Random.value < towerType)
                f |= Flags.TowerType;
            var lightRandom = Random.value;
            if (lightRandom < lightOn)
                f |= Flags.LightOn;
            if (lightRandom < lightOn + lightBlink)
                f |= Flags.LightBlink;
            return f;
        }
    }

    [Serializable]
    internal struct FlagsChecker
    {
        [SerializeField]
        private Player.State.Value[] statesMap;
        
        public Player.State.Value ExpectedState(Flags flags)
        {
            return statesMap[(int)flags];
        }
    }
}