using System;
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;
using Debug = System.Diagnostics.Debug;

namespace Scenes.MouseTryNoMerge
{
    public class Key : MonoBehaviour
    {
        [SerializeField] private Canvas canvas;
        private Boolean _keyStatus;
        
        // Start is called before the first frame update
        void Start()
        {
            _keyStatus = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (!_keyStatus) return;
            if (UnityEngine.Camera.main is null) return;
            var worldPosition = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var width = canvas.GetComponent<RectTransform>().rect.width;
            var height = canvas.GetComponent<RectTransform>().rect.height;
            worldPosition.x = worldPosition.x/9.0f * width * 0.5f;
            worldPosition.y = worldPosition.y/5.0f * height * 0.5f;
            worldPosition.z = 0f;
            gameObject.GetComponent<Transform>().localPosition = new Vector3(worldPosition.x,worldPosition.y,0f);
            // print("worldPosition" + worldPosition);
        }

        public void ChangeKeyStatus()
        {
            _keyStatus = !_keyStatus;
            Cursor.visible = !_keyStatus;
        }
        
    }
}
