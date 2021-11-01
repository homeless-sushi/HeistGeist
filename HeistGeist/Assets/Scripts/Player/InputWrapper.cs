using UnityEngine;

namespace Player
{
    public readonly struct InputWrapper
    {
        public readonly Vector2 direction;
        public readonly bool crouch;
        public readonly bool interact;
        
        public InputWrapper(Vector2 direction, bool crouch, bool interact)
        {
            this.direction = direction;
            this.crouch = crouch;
            this.interact = interact;
        }
    }
}