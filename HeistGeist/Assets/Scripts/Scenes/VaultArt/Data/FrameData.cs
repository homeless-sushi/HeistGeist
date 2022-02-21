using UnityEngine;

namespace Scenes.VaultArt.Data
{
    [CreateAssetMenu(menuName = "Frame Data")]
    public class FrameData : ScriptableObject
    {
        [SerializeField] private Sprite frame;
        public Sprite Frame => frame;
        
        //frame sprite on Inspect UI
        [SerializeField] private Sprite uIFrame;
        public Sprite UIFrame => uIFrame;
    }
}