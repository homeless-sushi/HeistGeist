using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Scenes.BankLaser
{
    [RequireComponent(typeof(Collider2D))]
    public class Laser : MonoBehaviour
    {
        [Serializable]
        public struct LaserSpriteRenderers
        {
            public SpriteRenderer upper, middle, lower;
        }
        [Space(10)]
        [Header("SpriteRenderers")]
        [SerializeField]
        private LaserSpriteRenderers laserSpriteRenderers;
        [Serializable]
        public struct TowerSpriteRenderers
        {
            public SpriteRenderer front, back;
        }
        [SerializeField]
        private TowerSpriteRenderers towerSpriteRenderers;
        [SerializeField]
        private SpriteRenderer lightSpriteRenderer;
        
        [Space(10)]
        [Header("Sprites")]
        [SerializeField]
        private float laserTransparency;
        [SerializeField]
        private TowerSpriteData[] towerSprites;
        [SerializeField]
        private LightSpriteData lightSprite;
        [SerializeField]
        private float lightBlinkSemiPeriod;
        [SerializeField]
        private float lightBlinkError;

        private bool _tallTowerFlag;
        private int _currentTowerType;
        private Coroutine _blinkCoroutine;

        private void Awake()
        {
            UpdateTowerSprites();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            // TODO
        }
    
        private void OnTriggerExit2D(Collider2D other)
        {
            // TODO
        }

        public void UpperLaserColor(Color color)
        {
            SetLaserColor(laserSpriteRenderers.upper, color);
        }

        public void MiddleLaserColor(Color color)
        {
            SetLaserColor(laserSpriteRenderers.middle, color);
        }

        public void LowerLaserColor(Color color)
        {
            SetLaserColor(laserSpriteRenderers.lower, color);
        }

        public void TowerType(int typeID)
        {
            _currentTowerType = typeID;
            UpdateTowerSprites();
        }

        public void TowerTall()
        {
            _tallTowerFlag = true;
            UpdateTowerSprites();
            laserSpriteRenderers.upper.enabled = true;
        }
        
        public void TowerShort()
        {
            _tallTowerFlag = false;
            UpdateTowerSprites();
            laserSpriteRenderers.upper.enabled = false;
        }

        public void LightOn()
        {
            ResetLight();
            SetLight(true);
        }
        
        public void LightOff()
        {
            ResetLight();
            SetLight(false);
        }
        
        public void LightBlink()
        {
            ResetLight();
            _blinkCoroutine = StartCoroutine(LightBlinkCoroutine());
        }

        private void SetLaserColor(SpriteRenderer laserSpriteRenderer, Color color)
        {
            color.a = laserTransparency;
            laserSpriteRenderer.color = color;
        }
        
        private TowerSpriteData.TowerSprite CurrentTowerSprites => _tallTowerFlag ? towerSprites[_currentTowerType].tallSprites : towerSprites[_currentTowerType].shortSprites;
        
        private void UpdateTowerSprites()
        {
            var sprites = CurrentTowerSprites;
            towerSpriteRenderers.front.sprite = sprites.front;
            towerSpriteRenderers.back.sprite = sprites.back;
            lightSpriteRenderer.transform.localPosition = sprites.lightOffset;
        }

        private void ResetLight()
        {
            if(_blinkCoroutine != null)
                StopCoroutine(_blinkCoroutine);
        }
        
        private void SetLight(bool status)
        {
            lightSpriteRenderer.sprite = status ? lightSprite.lightOn : lightSprite.lightOff;
        }

        private IEnumerator LightBlinkCoroutine()
        {
            print(lightBlinkSemiPeriod);
            while(true)
            {
                SetLight(true);
                yield return new WaitForSeconds(lightBlinkSemiPeriod + Random.Range(-lightBlinkError, lightBlinkError));
                SetLight(false);
                yield return new WaitForSeconds(lightBlinkSemiPeriod + Random.Range(-lightBlinkError, lightBlinkError));
            }
        }
    }
}
