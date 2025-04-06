using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float totalTime = 60f; // 1 minuto em segundos
    private float timeRemaining;
    private bool isRunning = true;

    // Propriedade pública estática para checar se o tempo acabou
    public static bool TimeOver { get; private set; } = false;

    void Start()
    {
        timeRemaining = totalTime;
        TimeOver = false;
    }

    void Update()
    {
        if (isRunning && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining < 0) timeRemaining = 0;
            UpdateTimerDisplay();
        }

        if (timeRemaining <= 0 && isRunning)
        {
            isRunning = false;
            OnTimerEnd(); // chama algo quando o tempo acabar
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60f);
        int seconds = Mathf.FloorToInt(timeRemaining % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void OnTimerEnd()
    {
        Debug.Log("Tempo esgotado!");
        TimeOver = true;
        // Aqui você pode adicionar lógica extra, tipo GameOver();
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public float GetRemainingTime()
    {
        return timeRemaining;
    }
}
