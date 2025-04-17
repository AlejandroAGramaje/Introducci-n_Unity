using UnityEngine;

public class BlueBlock : MonoBehaviour
{
    public GameObject spark;
    public AudioClip breakSound;
    public GameObject secondPaddle;

    private AudioSource audioSource;

    void Start()
    {
        LevelManager.numInitialBlocks++;
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (spark != null)
        {
            GameObject sparkInstance = Instantiate(spark, transform.position, Quaternion.identity);
            Destroy(sparkInstance, 1f);
        }

        if (audioSource != null && breakSound != null)
            audioSource.PlayOneShot(breakSound);

        UIManager.instance.AddScore(30);

        if (secondPaddle != null && !secondPaddle.activeSelf)
        {
            secondPaddle.SetActive(true);
            secondPaddle.GetComponent<FadingPaddle>().StartFading();
            // ya no hace falta moverla aquí, el PaddleController la sincroniza
        }

        Destroy(gameObject);
        LevelManager.numInitialBlocks--;
    }
}
