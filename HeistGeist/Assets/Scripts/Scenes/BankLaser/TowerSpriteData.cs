using System;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

namespace Scenes.BankLaser
{
    [CreateAssetMenu(menuName = "Laser Tower Sprites")]
    public class TowerSpriteData : ScriptableObject
    {
        [Serializable]
        public struct TowerSprite
        {
            public Sprite front, back;
            public Vector3 lightOffset;
        }
        public TowerSprite tallSprites;
        public TowerSprite shortSprites;
    }
}