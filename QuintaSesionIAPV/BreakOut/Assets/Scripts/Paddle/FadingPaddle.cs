using UnityEngine;

public class FadingPaddle : MonoBehaviour
{
    private Renderer rend;
    private Color startColor = Color.white;
    private Color endColor = new Color(1, 1, 1, 0); // blanco transparente
    private Vector3 originalScale;
    private float fadeDuration = 3f; // duración del efecto final (puedes ajustarlo)
    private float fadeTimer = 0f;
    private bool isFading = false;

    private Material materialInstance;

    void Start()
    {
        rend = GetComponent<Renderer>();
        originalScale = transform.localScale;

        // Crear instancia del material para no afectar otros objetos
        materialInstance = new Material(rend.material);
        rend.material = materialInstance;
    }

    public void StartFading()
    {
        fadeTimer = 0f;
        isFading = true;
        materialInstance.color = startColor;
        transform.localScale = originalScale;
    }

    void Update()
    {
        if (!isFading) return;

        fadeTimer += Time.deltaTime;
        float t = Mathf.Clamp01(fadeTimer / fadeDuration);

        // Interpolar color (desvanecerse)
        materialInstance.color = Color.Lerp(startColor, endColor, t);

        // Interpolar escala (encogerse)
        transform.localScale = Vector3.Lerp(originalScale, Vector3.zero, t);

        if (t >= 1f)
        {
            isFading = false;
            gameObject.SetActive(false); // al final se desactiva
        }
    }

    void OnDisable()
    {
        // Restaurar valores por si se reactiva más tarde
        if (materialInstance != null)
            materialInstance.color = startColor;

        transform.localScale = originalScale;
    }
}
