using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyPatrol : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;

    private Transform target;
    private Rigidbody2D rb;
    private bool facingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = pointB;
    }

    void FixedUpdate()
    {
        if (target == null || pointA == null || pointB == null) return;

        // Déplacement vers la cible
        Vector2 targetPos = new Vector2(target.position.x, rb.position.y); // Reste au sol
        Vector2 newPosition = Vector2.MoveTowards(rb.position, targetPos, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPosition);

        // Inversion de direction
        if (Vector2.Distance(rb.position, targetPos) < 0.2f)
        {
            target = (target == pointA) ? pointB : pointA;
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
