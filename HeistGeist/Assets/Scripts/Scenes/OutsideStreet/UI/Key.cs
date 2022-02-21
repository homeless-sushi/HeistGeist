using System;
using UnityEngine;
using Cursor = UnityEngine.Cursor;

namespace Scenes.OutsideStreet.UI
{
    public class Key : MonoBehaviour
    {
        [SerializeField] private UnityEngine.Camera uiCamera;
        [SerializeField] private Canvas canvas;
        private Boolean _isHeld;

        [SerializeField] private int keyNumber;
        public int KeyNumber { set; get; } 
        
        void Start()
        {
            _isHeld = false;
        }

        void Update()
        {
            if (!_isHeld) return;
            if (uiCamera == null) return;
            
            var worldPosition = uiCamera.ScreenToWorldPoint(Input.mousePosition);
            var width = canvas.GetComponent<RectTransform>().rect.width;
            var height = canvas.GetComponent<RectTransform>().rect.height;
            
            var cameraVerticalSize = uiCamera.orthographicSize;
            var cameraHorizontalSize = cameraVerticalSize * uiCamera.aspect;
            
            worldPosition.x = worldPosition.x/cameraHorizontalSize * width * 0.5f;
            worldPosition.y = worldPosition.y/uiCamera.orthographicSize * height * 0.5f;
            worldPosition.z = 0f;
            gameObject.GetComponent<Transform>().localPosition = worldPosition;
            
        }

        public void ChangeKeyStatus()
        {
            _isHeld = !_isHeld;
            Cursor.visible = !_isHeld;
        }

        void OnDisable()
        {
            _isHeld = false;
            Cursor.visible = true;
        }
    }
}
