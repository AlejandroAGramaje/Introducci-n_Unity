using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalDetector : MonoBehaviour
{
    public GameObject victoryPanel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0f; 
            if (victoryPanel != null)
                victoryPanel.SetActive(true);
        }
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
