using UnityEngine;

public class TriangleMovement : MonoBehaviour
{
    public Vector2 direction = Vector2.right;
    public float speed = 2f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
            rb.gravityScale = 0;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = direction * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("WallHorizontal"))
        {
            // Inverter direção vertical (eixo Y)
            direction = new Vector2(direction.x,1);
        }
        else if (other.CompareTag("WallHorizontalUp"))
        {
            // Inverter direção vertical (eixo Y)
            direction = new Vector2(direction.x, -1);
        }
        else if (other.CompareTag("WallVertical"))
        {
            // Inverter direção horizontal (eixo X)
            direction = new Vector2(-direction.x, direction.y);
        }

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player pegou o triângulo!");
            Destroy(gameObject);
        }
    }
}
