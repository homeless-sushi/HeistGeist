using Camera;
using UnityEngine;

namespace Teleport
{
    public class Teleporter : MonoBehaviour
    {
        [SerializeField] private CameraBoundsData roomCameraBoundsData;
        [SerializeField] private Vector2 teleportLocation;

        public void Teleport()
        {
            BoundedFollowCamera mainCamera =
                UnityEngine.Camera.main!.GetComponent<BoundedFollowCamera>();
            mainCamera.SetBounds(
                roomCameraBoundsData.CameraLowerBounds,
                roomCameraBoundsData.CameraUpperBounds);
            mainCamera.transform.position = 
                new Vector3(
                    teleportLocation.x,
                    teleportLocation.y,
                    mainCamera.transform.position.z);
            
            GameObject player = GameObject.FindWithTag("Player");
            player.transform.position = teleportLocation;
        }
    }
}

