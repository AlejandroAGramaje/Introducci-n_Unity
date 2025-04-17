using UnityEngine;

public class TexturePainter : MonoBehaviour
{
    public Renderer targetRenderer; // El plano o quad que tendrá la textura
    private Texture2D texture;

    void Start()
    {
        texture = new Texture2D(64, 64, TextureFormat.RGBA32, false);

        // Pintamos de blanco al principio
        Color[] pixels = new Color[64 * 64];
        for (int i = 0; i < pixels.Length; i++)
            pixels[i] = Color.white;

        texture.SetPixels(pixels);
        texture.Apply();

        targetRenderer.material.mainTexture = texture;
    }

    public void PintarColorAleatorio()
    {
        Color[] pixels = new Color[64 * 64];
        Color colorAleatorio = new Color(Random.value, Random.value, Random.value);

        for (int i = 0; i < pixels.Length; i++)
            pixels[i] = colorAleatorio;

        texture.SetPixels(pixels);
        texture.Apply();
    }
}
