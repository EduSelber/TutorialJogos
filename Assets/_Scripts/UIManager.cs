using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject endGamePanel;
    private GameTimer gameTimer;

    void Start()
    {
        gameTimer = FindObjectOfType<GameTimer>();
    }

    void FixedUpdate()
    {
        if (GameControler.gameOver || GameTimer.TimeOver)
        {
            gameTimer.StopTimer();
            endGamePanel.SetActive(true);
        }
    }
}
