using UnityEngine;

public class RedBlock : MonoBehaviour
{
    public GameObject spark; // Partículas
    public AudioClip breakSound; // Clip de sonido

    private AudioSource audioSource;

    void Start()
    {
        LevelManager.numInitialBlocks++;
        audioSource = GetComponent<AudioSource>(); // o puedes usar AddComponent<AudioSource>() si no lo tiene
    }

    void OnCollisionEnter(Collision collision)
    {
        // Sonido
        if (breakSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(breakSound);
        }

        // Partículas
        if (spark != null)
        {
            GameObject sparkInstance = Instantiate(spark, transform.position, Quaternion.identity);
            Destroy(sparkInstance, 1f); // ← asegúrate de este paso o de usar Stop Action = Destroy
            Destroy(gameObject); // destruye el bloque

        }

        // Destruir el bloque con retraso para que se oiga el sonido
        UIManager.instance.AddScore(10);
        LevelManager.numInitialBlocks--;
        Destroy(gameObject, 0.1f); // da tiempo al sonido a reproducirse
    }
}
