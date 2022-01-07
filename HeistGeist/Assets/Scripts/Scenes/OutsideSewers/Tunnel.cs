using System;
using UnityEngine;

namespace Scenes.OutsideSewers
{
    public class Tunnel : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        public bool isExit;
        
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            print(isExit ? "Enter" : "Wrong");
        }

        public void SetSprite(Sprite sprite)
        {
            _spriteRenderer.sprite = sprite;
        }
    }
}