using UnityEngine;

public class GoalPlatform : MonoBehaviour
{
    public GameObject winTextUI;

    void Start()
    {
        if (winTextUI != null) {winTextUI.SetActive(false); }
             
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("¡Nivel completado!");
            if (winTextUI != null)
            {
                winTextUI.SetActive(true);
            }
        }
    }
}