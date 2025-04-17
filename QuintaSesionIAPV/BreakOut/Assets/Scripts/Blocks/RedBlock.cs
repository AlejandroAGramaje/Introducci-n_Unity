using UnityEngine;

public class RedBlock : MonoBehaviour
{
    public GameObject spark; // Partículas
    public AudioClip breakSound; // Clip de sonido

    private AudioSource audioSource;

    void Start()
    {
        LevelManager.numInitialBlocks++;
        audioSource = GetComponent<AudioSource>(); 
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
            Destroy(sparkInstance, 1f);
            Destroy(gameObject); 

        }
        FindObjectOfType<TexturePainter>().PintarColorAleatorio();


       
        UIManager.instance.AddScore(10);
        LevelManager.numInitialBlocks--;
        Destroy(gameObject, 0.1f);
    }
}
