using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    private int bonus = 0;
    private int scoreFinal = 0;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI BonusText;
    public TextMeshProUGUI ScoreFinal;

    private float initialTime;
    private GameTimer gameTimer;

    void Start()
    {
        gameTimer = Object.FindFirstObjectByType<GameTimer>();
        initialTime = gameTimer.totalTime;
    }

    void Update()
    {
        if (GameControler.gameOver || GameTimer.TimeOver || GameControler.CapturedReporter)
        {
            CalculateFinalScore();
            

            enabled = false;
        }
    }

    public void AddScore()
    {
        if (!GameControler.gameOver && !GameTimer.TimeOver && !GameControler.CapturedReporter)
        {
            score += 100;
        }
    }

    private void CalculateFinalScore()
    {
        float timeUsed = initialTime - gameTimer.GetRemainingTime();
        float timeUsedPercentage = Mathf.Clamp01(timeUsed / initialTime); 
        if (!GameControler.CapturedReporter) { 
        bonus = Mathf.RoundToInt(score * (1 - timeUsedPercentage));
        }
        else
        {
            bonus = 0;
        }
        scoreFinal = score + bonus;

        if (scoreText != null) scoreText.text = $"{score}";
        if (BonusText != null) BonusText.text = $"{bonus}";
        if (ScoreFinal != null) ScoreFinal.text = $"{scoreFinal}";
    }

    public int GetFinalScore() => scoreFinal;
    public int GetRawScore() => score;
    public int GetBonus() => bonus;
}
