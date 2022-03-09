using UnityEngine;

namespace Keypad.Data
{
    [CreateAssetMenu(menuName = "KeypadButton Data")]
    public class KeypadButtonData : ScriptableObject
    {
        [SerializeField] private Sprite buttonGrey;
        public Sprite ButtonGrey => buttonGrey;
        
        [SerializeField] private Sprite buttonGreen;
        public Sprite ButtonGreen => buttonGreen;
        
        [SerializeField] private Sprite buttonRed;
        public Sprite ButtonRed => buttonRed;

        [SerializeField] private int number;
        public int Number => number;
    }
}