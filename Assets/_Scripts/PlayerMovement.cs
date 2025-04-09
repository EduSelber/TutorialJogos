using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private AudioSource audio;
    private AudioSource audio1;
    public float speed;

    private ScoreManager scoreManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        scoreManager = Object.FindFirstObjectByType<ScoreManager>();

        AudioSource[] audios = GetComponents<AudioSource>(); 
        audio = audios[0];
        audio1 = audios[1];
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
        if (other.tag == "Coletavel" && (!GameControler.gameOver && !GameTimer.TimeOver && !GameControler.CapturedReporter))
        {
            audio.Play();
            scoreManager.AddScore();
            GameControler.Collect();
            Destroy(other.gameObject);
        }
        if (other.tag == "Reporter" && (!GameControler.gameOver && !GameTimer.TimeOver && !GameControler.CapturedReporter))
        {
            audio1.Play();
            GameControler.CaptureReporter();
        }
    }
}
