using System;
using UnityEngine;

namespace Scenes.BankLaser
{
    [CreateAssetMenu(menuName = "Laser Light Sprites")]
    public class LightSpriteData : ScriptableObject
    {
        public Sprite lightOff;
        public Sprite lightOn;
    }
}