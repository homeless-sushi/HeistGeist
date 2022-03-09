using UnityEngine;

namespace Camera
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] protected Transform targetTransform; //Transform of the target to follow
        [SerializeField] [Range(0f,1f)] protected float smoothing = .5f; //Smoothing factor
        protected virtual void FixedUpdate()
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
