
using UnityEngine;
using UnityEngine.Events;

namespace Scenes.OutsideSewers
{
    public class Tunnel : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        public bool isExit;
        [SerializeField]
        private UnityEvent exit;
        [SerializeField]
        private UnityEvent fail;
        
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            // Ignore non player collisions
            if(!other.CompareTag("Player"))
                return;
            if(isExit)
                exit.Invoke();
            else
                fail.Invoke();
        }

        public void SetSprite(Sprite sprite)
        {
            _spriteRenderer.sprite = sprite;
        }
    }
}