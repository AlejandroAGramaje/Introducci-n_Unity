using UnityEngine;

public class FlashingPaddle : MonoBehaviour
{
    private Renderer rend;
    private bool isFlashing = false;
    private float flashTimer = 0f;
    private float interval = 1f; // empieza con parpadeo lento

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    public void StartFlashing()
    {
        isFlashing = true;
        flashTimer = 0f;
        interval = 1f;
    }

    void Update()
    {
        if (!isFlashing) return;

        flashTimer += Time.deltaTime;

        // Disminuir el intervalo progresivamente
        if (interval > 0.1f)
            interval -= Time.deltaTime / 30f; // parpadeo más rápido con el tiempo

        if (flashTimer >= interval)
        {
            rend.enabled = !rend.enabled; // alterna visibilidad
            flashTimer = 0f;
        }
    }

    void OnDisable()
    {
        // Restaurar visibilidad cuando se desactiva
        if (rend != null)
            rend.enabled = true;
        isFlashing = false;
    }
}
