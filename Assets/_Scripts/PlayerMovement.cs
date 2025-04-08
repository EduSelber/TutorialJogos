using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;

    private ScoreManager scoreManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        scoreManager = Object.FindFirstObjectByType<ScoreManager>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coletavel")
        {
            // as_audio.Play();
            GameControler.Collect();
            scoreManager.AddScore();
            Destroy(other.gameObject);
        }
    }
}
