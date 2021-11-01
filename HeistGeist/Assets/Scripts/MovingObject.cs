using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class MovingObject : MonoBehaviour
{
    public Rigidbody2D Rigidbody { get; private set; }
    
    protected virtual void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 dirVector, float velocity)
    {
        Vector2 target = (Vector2)transform.position + velocity*Time.fixedDeltaTime*dirVector.normalized;
        //RaycastHit2D hit = CanMove(target);
        // if (CanMove(target).transform == null)
        //{
            Rigidbody.MovePosition(target);
            return;
        //}

        //OnCantMove(hit, target);
    }

    //protected abstract RaycastHit2D CanMove(Vector3 end);

    //protected abstract void OnCantMove(RaycastHit2D hit, Vector2 target);
}