using System.IO;

namespace keypad.KeypadState
{
    public abstract class KeyState
    {
        protected string ImageColor;

        public string GetColor()
        {
            return ImageColor;
        }
    }

}