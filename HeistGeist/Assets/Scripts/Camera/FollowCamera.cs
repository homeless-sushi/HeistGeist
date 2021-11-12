using UnityEngine;

namespace Camera
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] private Transform targetTransform; //Transform of the target to follow
        [SerializeField] [Range(0f,1f)] private float smoothing = .5f; //Smoothing factor
        private void FixedUpdate()
        {
            Vector3 targetPosition = targetTransform.position;
            targetPosition.z = transform.position.z;
            if ((transform.position - targetPosition).sqrMagnitude > float.Epsilon)
            {
                transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
            }
        }
    }
}
