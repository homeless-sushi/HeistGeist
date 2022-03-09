using UnityEngine;
using UnityEngine.U2D;

namespace Camera
{
    [RequireComponent(typeof(UnityEngine.Camera))]
    [RequireComponent(typeof(PixelPerfectCamera))]
    public class BoundedFollowCamera : FollowCamera
    {
        private UnityEngine.Camera _camera;
        private PixelPerfectCamera _pixelPerfectCamera;
        
        private Vector2 _lowerBounds;
        private Vector2 _upperBounds;
        [SerializeField] public Vector2 lowerBounds;
        [SerializeField] public Vector2 upperBounds;

        protected void Awake()
        {
            _camera = GetComponent<UnityEngine.Camera>();
            _pixelPerfectCamera = GetComponent<PixelPerfectCamera>();
            SetBounds(lowerBounds, upperBounds);
        }

        protected override void FixedUpdate()
        {
            Vector3 targetPosition = targetTransform.position;
            targetPosition.x 
                = Mathf.Clamp(targetPosition.x, _lowerBounds.x, _upperBounds.x);
            targetPosition.y
                = Mathf.Clamp(targetPosition.y, _lowerBounds.y, _upperBounds.y);
            targetPosition.z = transform.position.z;
            if ((transform.position - targetPosition).sqrMagnitude > float.Epsilon)
            {
                transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
            }
        }

        public void SetBounds(Vector2 lowerBounds, Vector2 upperBounds)
        {
            
            float halfHeight = 
                _pixelPerfectCamera.refResolutionY / ((float)_pixelPerfectCamera.assetsPPU*2);
            float halfWidth = 
                _pixelPerfectCamera.refResolutionX / ((float)_pixelPerfectCamera.assetsPPU*2);

            _lowerBounds.x = lowerBounds.x + halfWidth;
            _lowerBounds.y = lowerBounds.y + halfHeight;
            _upperBounds.x = upperBounds.x - halfWidth;
            _upperBounds.y = upperBounds.y - halfHeight;
        }
    }
}