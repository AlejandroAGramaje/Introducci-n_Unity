using UnityEngine;

public class YellowBlock : MonoBehaviour
{
    public GameObject spark; // Part�culas
    public AudioClip breakSound; // Clip de sonido

    private AudioSource audioSource;
    private int touches = 2;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        LevelManager.numInitialBlocks++;
    }

    void OnCollisionEnter(Collision collision)
    {
        touches--;

        if (touches == 0)
        {
            // Sonido
            if (breakSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(breakSound);
            }

            // Part�culas
            if (spark != null)
            {
                Instantiate(spark, transform.position, Quaternion.identity);
            }

            UIManager.instance.AddScore(10);
            LevelManager.numInitialBlocks--;
            Destroy(gameObject, 0.1f); // le das un peque�o retardo para que suene el sonido
        }
       
    }
}