using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Scenes.BankLaser
{
    [RequireComponent(typeof(Collider2D))]
    internal class Laser : MonoBehaviour
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

        private void Start()
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
            laserSpriteRenderers.upper.color = color;
        }

        public void MiddleLaserColor(Color color)
        {
            laserSpriteRenderers.middle.color = color;
        }

        public void LowerLaserColor(Color color)
        {
            laserSpriteRenderers.lower.color = color;
        }

        public void TowerType(int typeID)
        {
            _currentTowerType = typeID;
        }

        public void TowerTall()
        {
            _tallTowerFlag = true;
        }
        
        public void TowerShort()
        {
            _tallTowerFlag = false;
        }
        
        public void UpdateTowerSprites()
        {
            laserSpriteRenderers.upper.enabled = _tallTowerFlag;
            var sprites = CurrentTowerSprites;
            towerSpriteRenderers.front.sprite = sprites.front;
            towerSpriteRenderers.back.sprite = sprites.back;
            lightSpriteRenderer.transform.localPosition = sprites.lightOffset;
        }

        public void Light(LightStatus status)
        {
            if(_blinkCoroutine != null)
                StopCoroutine(_blinkCoroutine);
            switch (status)
            {
                case LightStatus.Off:
                    SetLightOff();
                    break;
                case LightStatus.On:
                    SetLightOn();
                    break;
                case LightStatus.Blink:
                    _blinkCoroutine = StartCoroutine(LightBlinkCoroutine());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(status));
            }
        }
        
        private TowerSpriteData.TowerSprite CurrentTowerSprites => _tallTowerFlag ? towerSprites[_currentTowerType].tallSprites : towerSprites[_currentTowerType].shortSprites;

        private void SetLightOn()
        {
            lightSpriteRenderer.sprite = lightSprite.lightOn;
        }

        private void SetLightOff()
        {
            lightSpriteRenderer.sprite = lightSprite.lightOff;
        }

        private IEnumerator LightBlinkCoroutine()
        {
            while(true)
            {
                SetLightOn();
                yield return new WaitForSeconds(lightBlinkSemiPeriod + Random.Range(-lightBlinkError, lightBlinkError));
                SetLightOff();
                yield return new WaitForSeconds(lightBlinkSemiPeriod + Random.Range(-lightBlinkError, lightBlinkError));
            }
        }
    }

    internal enum LightStatus
    {
        Off = 0,
        On = 1,
        Blink = 2,
    }
}
