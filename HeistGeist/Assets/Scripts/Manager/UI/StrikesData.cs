using UnityEngine;

namespace Manager.UI
{
    [CreateAssetMenu(menuName = "Strike Data")]
    public class StrikesData : ScriptableObject
    {
        [SerializeField] private Sprite strikeWhite;
        public Sprite StrikeWhite => strikeWhite;
        
        [SerializeField] private Sprite strikeRed;
        public Sprite StrikeRed => strikeRed;
    }
}





   
        
  