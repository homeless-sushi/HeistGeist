using UnityEngine;

namespace Camera
{
    [CreateAssetMenu(menuName = "CameraBounds Data")]
    public class CameraBoundsData : ScriptableObject
    {
        [SerializeField] private Vector2 cameraLowerBounds;
        public Vector2 CameraLowerBounds => cameraLowerBounds;
        [SerializeField] private Vector2 cameraUpperBounds;
        public Vector2 CameraUpperBounds => cameraUpperBounds;
    }
}
