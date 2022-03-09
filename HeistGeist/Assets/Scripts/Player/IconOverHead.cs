using JetBrains.Annotations;
using UnityEngine;

namespace Player
{
    public class IconOverHead : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer iconOverHead;

        public void SetIconOverHead([CanBeNull] Sprite icon)
        {
            iconOverHead.sprite = icon;
        }
    }
}