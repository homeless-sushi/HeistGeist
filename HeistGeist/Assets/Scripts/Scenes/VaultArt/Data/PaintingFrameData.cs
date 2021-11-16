using UnityEngine;

namespace Scenes.VaultArt.Data
{
    [CreateAssetMenu(menuName = "PaintingFrame Data")]
    public class PaintingFrameData : ScriptableObject
    {
        [SerializeField] private Sprite painting;
        public Sprite Painting => painting;
        
        //frame sprite on Inspect UI
        [SerializeField] private Sprite uIPainting;
        public Sprite UIPainting => uIPainting;

        //frame sprites
        [SerializeField] private FrameData frameData;
        public FrameData FrameData=> frameData;
    }
}
