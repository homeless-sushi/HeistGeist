using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovingObject : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    public Vector2 velocity = Vector2.zero;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        var target = _rigidbody.position + velocity * Time.fixedDeltaTime;
        _rigidbody.MovePosition(target);
    }
}