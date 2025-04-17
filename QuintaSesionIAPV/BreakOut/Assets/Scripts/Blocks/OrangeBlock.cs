using UnityEngine;

public class OrangeBlock : MonoBehaviour
{
    public GameObject spark; // Partículas
    public AudioClip breakSound; // Clip de sonido

    private AudioSource audioSource;
    private Material matInstancia;
    private float dano = 0f;
    private int vidas = 3;

    void Start()
    {
        LevelManager.numInitialBlocks++;

        audioSource = GetComponent<AudioSource>();

        Renderer renderer = GetComponent<Renderer>();
        matInstancia = renderer.material;
        matInstancia.SetFloat("_Dano", 0f); // 🔧 nombre actualizado
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ball")) return;

        if (breakSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(breakSound);
        }

        if (spark != null)
        {
            GameObject sparkInstance = Instantiate(spark, transform.position, Quaternion.identity);
            Destroy(sparkInstance, 1f);
        }

        FindObjectOfType<TexturePainter>().PintarColorAleatorio();

        vidas--;
        dano += 0.5f;
        dano = Mathf.Clamp01(dano); // Previene que pase de 1

        if (matInstancia != null)
        {
            Debug.Log("DANO: " + dano); //  para verificar
            matInstancia.SetFloat("_Dano", dano);
        }

        if (vidas <= 0)
        {
            UIManager.instance.AddScore(30);
            LevelManager.numInitialBlocks--;
            Destroy(gameObject, 0.1f);
        }
    }
}

