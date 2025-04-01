using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;

    private int score = 0;
    private int lives = 3;

    public static UIManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateUI();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateUI();
    }

    public void LoseLife()
    {
        lives--;
        UpdateUI();
        if (lives <= 0)
        {
            SceneManager.LoadScene("LoseScene");
        }
    }

    void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "Puntuación: " + score;
        if (livesText != null)
            livesText.text = "Vidas: " + lives;
    }

    public void WinGame()
    {
        SceneManager.LoadScene("WinScene");
    }
}
