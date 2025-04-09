using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private AudioSource audio;
    private AudioSource audio1;
    public float speed;

    private ScoreManager scoreManager;
    private PlayerControls_Valid controls;
    private Vector2 moveInput;

    void Awake()
    {
        controls = new PlayerControls_Valid();

        // Sempre que houver input, atualiza a variável moveInput
        controls.Gameplay.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled += ctx => moveInput = Vector2.zero;
    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
    }

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
        // Aplica o movimento com a velocidade e direção
        rb.MovePosition(rb.position + moveInput.normalized * speed * Time.fixedDeltaTime);
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
