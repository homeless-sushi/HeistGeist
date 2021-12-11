using System;
using UnityEngine;

namespace Scenes.OutsideSewers
{
    public class Tunnel : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            print("Enter");
        }
    }
}