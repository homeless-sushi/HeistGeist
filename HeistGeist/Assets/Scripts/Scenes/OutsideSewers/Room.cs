using Camera;
using Teleport;
using UnityEngine;

namespace Scenes.OutsideSewers
{
    public class Room : MonoBehaviour
    {
        [SerializeField] private CameraBoundsData cameraBoundaries;
        [SerializeField] private Vector2 spawnPoint;
        
        public Tunnel[] tunnels;
        private Vector3 _absSpawnPoint;
        private Vector2 _absCameraLowerBounds;
        private Vector2 _absCameraUpperBounds;

        private void Awake()
        {
            var position = transform.position;
            _absSpawnPoint = new Vector3(
                position.x + spawnPoint.x,
                position.y + spawnPoint.y,
                position.z
            );
            var positionV2 = new Vector2(position.x, position.y);
            _absCameraLowerBounds = cameraBoundaries.CameraLowerBounds + positionV2;
            _absCameraUpperBounds = cameraBoundaries.CameraUpperBounds + positionV2;
            tunnels = GetComponentsInChildren<Tunnel>();
        }

        public void Teleport()
        {
            var mainCamera = UnityEngine.Camera.main!.GetComponent<BoundedFollowCamera>();
            mainCamera.SetBounds(
                _absCameraLowerBounds,
                _absCameraUpperBounds
            );
            mainCamera.transform.position = new Vector3(
                _absSpawnPoint.x,
                _absSpawnPoint.y,
                mainCamera.transform.position.z
            );
            
            GameObject.FindWithTag("Player").transform.position = _absSpawnPoint;
        }
    }
}