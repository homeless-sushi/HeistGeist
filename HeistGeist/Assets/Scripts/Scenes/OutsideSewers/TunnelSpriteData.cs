using UnityEngine;

namespace Scenes.OutsideSewers
{
    [CreateAssetMenu(menuName = "Sewers Tunnel Sprites")]
    public class TunnelSpriteData : ScriptableObject
    {
        public Sprite normal, wet, mossy, muddy;
    }
}