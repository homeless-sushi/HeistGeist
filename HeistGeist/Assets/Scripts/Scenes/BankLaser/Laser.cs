using UnityEngine;

namespace Scenes.BankLaser
{
    [RequireComponent(typeof(Collider2D))]
    public class Laser : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer[] laserSprites;
        [SerializeField]
        private SpriteRenderer lightSprite;

        [SerializeField] private Sprite Tower;
    
        public Color LaserColor
        {
            get => laserSprites[0].color;
            set => laserSprites[0].color = value;
        }
        private Color _laserColor;

        private void Awake()
        {
            SetColor(0, Color.red);
            SetColor(1, Color.blue);
            SetLight(true);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            SetColor(0, Color.yellow);
            SetColor(1, Color.green);
            SetLight(false);
        }
    
        private void OnTriggerExit2D(Collider2D other)
        {
            SetColor(0, Color.red);
            SetColor(1, Color.blue);
            SetLight(true);
        }

        public void SetColor(int laserId, Color color)
        {
            laserSprites[laserId].color = color;
        }
    
        public void SetLight(bool on)
        {
            lightSprite.color = on ? Color.yellow : Color.black;
        }
    }
}
