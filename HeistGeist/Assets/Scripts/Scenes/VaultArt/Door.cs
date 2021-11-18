using UnityEngine;
using UnityEngine.Events;

namespace Scenes.VaultArt
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private Sprite openSprite;
        //[SerializeField] private Sprite closedSprite;
        private SpriteRenderer _doorSpriteRenderer;
        [SerializeField] private Collider2D doorCollider;

        //[SerializeField] private UnityEvent enterEvent;
        //private bool open = false;

        private void Awake()
        {
            _doorSpriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            //enterEvent.Invoke();
            print("enter");
        }

        public void Open()
        {
            //open = true;
            _doorSpriteRenderer.sprite = openSprite;
            doorCollider.enabled = false;
        }
        /*
        public void Close()
        {
            open = false;
            _doorSpriteRenderer.sprite = openSprite;
            doorCollider.enabled = true;
        }
        */
        [SerializeField] private int[] code;

        public void SetCode(int[] code)
        {
            this.code = code;
        }
    }
}
