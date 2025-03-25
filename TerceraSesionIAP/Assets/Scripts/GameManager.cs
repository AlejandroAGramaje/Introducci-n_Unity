using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI timeText;
    public AudioSource music;
    public GameObject defeatPanel;


    public float totalTime = 30f;
    private float timeRemaining;
    private bool isPaused = false;
    private bool gameEnded = false;

    void Start()
    {
        timeRemaining = totalTime;
        Time.timeScale = 1f;

        if (levelText != null)
            levelText.text = "Nivel: Plataforma";

        if (music != null)
            music.pitch = 1f;
    }

    void Update()
    {
        if (!gameEnded && !isPaused)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerUI();

            if (timeRemaining <= 0)
            {
                gameEnded = true;
                Time.timeScale = 0f;
                timeText.text = "¡Tiempo agotado!";

                if (defeatPanel != null)
                    defeatPanel.SetActive(true);
            }

        }
    }

    void UpdateTimerUI()
    {
        timeText.text = "Tiempo: " + Mathf.CeilToInt(timeRemaining);

        if (timeRemaining <= 5f)
        {
            float t = Mathf.PingPong(Time.time * 4f, 1f); 
            timeText.color = Color.Lerp(Color.red, Color.white, t);

            if (music != null)
                music.pitch = 1.5f;
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

