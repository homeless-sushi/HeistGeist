using UnityEngine;

namespace Scenes.OutsideStreet.Data
{
    [CreateAssetMenu(menuName = "KeyKeyhole Data")]
    public class KeyKeyholeData : ScriptableObject
    {
        [SerializeField] private Sprite keyhole;
        public Sprite Keyhole => keyhole;
        
        [SerializeField] private Sprite key;
        public Sprite Key => key;
        
        [SerializeField] private int keyNumber;
        public int KeyNumber => keyNumber;
    }
}