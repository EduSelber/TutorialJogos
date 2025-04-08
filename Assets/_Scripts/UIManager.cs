using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject endGamePanel;
    private GameTimer gameTimer;

    void Start()
    {
        gameTimer = Object.FindFirstObjectByType<GameTimer>();
    }

    void FixedUpdate()
    {
        if (GameControler.gameOver || GameTimer.TimeOver || GameControler.CapturedReporter)
        {
            gameTimer.StopTimer();
            endGamePanel.SetActive(true);
        }
    }
}
