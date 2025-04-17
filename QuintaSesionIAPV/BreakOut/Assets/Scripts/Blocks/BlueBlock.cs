using UnityEngine;
using System.Collections;

public class BlueBlock : MonoBehaviour
{
    public GameObject spark;
    public AudioClip breakSound;
    public GameObject secondPaddle;

    [SerializeField] private Material dissolveMaterial; 

    private AudioSource audioSource;
    private Material matInstancia;
    private float disolver = 0f;

    void Start()
    {
        LevelManager.numInitialBlocks++;
        audioSource = GetComponent<AudioSource>();

        
        matInstancia = GetComponent<Renderer>().material;
        matInstancia.CopyPropertiesFromMaterial(dissolveMaterial); 
        matInstancia.SetFloat("_Disolver", 0f);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ball")) return;

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
        }

        StartCoroutine(DissolveAndDestroy());
    }

    IEnumerator DissolveAndDestroy()
    {
        float t = 0f;
        while (t < 1f)
        {
            disolver = Mathf.Lerp(0f, 1f, t);
            matInstancia.SetFloat("_Disolver", disolver);
            t += Time.deltaTime * 2f; 
            yield return null;
        }

        LevelManager.numInitialBlocks--;
        Destroy(gameObject);
    }
}
