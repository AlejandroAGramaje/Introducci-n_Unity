using UnityEngine;

public class GeneradorBloques3D : MonoBehaviour
{
    [System.Serializable]
    public class BloqueConProbabilidad
    {
        public GameObject prefab;
        public float probabilidad;
    }

    public BloqueConProbabilidad[] bloques;
    public int filas = 5;        // Z
    public int columnas = 10;    // X
    public float separacionX = 1.1f;
    public float separacionZ = 1.1f;
    public float alturaY = 0.25f; // Fijo
    public Vector2 posicionInicial = new Vector2(-5f, 1.5f); // X y Z inicial

    void Start()
    {
        for (int fila = 0; fila < filas; fila++)
        {
            for (int col = 0; col < columnas; col++)
            {
                Vector3 posicion = new Vector3(
                    posicionInicial.x + col * separacionX, // X
                    alturaY,                               // Y
                    posicionInicial.y + fila * separacionZ // Z
                );

                GameObject prefabElegido = ElegirBloquePorProbabilidad();
                Instantiate(prefabElegido, posicion, Quaternion.identity, this.transform);
            }
        }
    }

    GameObject ElegirBloquePorProbabilidad()
    {
        float total = 0f;
        foreach (var bloque in bloques)
            total += bloque.probabilidad;

        float random = Random.Range(0f, total);
        float acumulado = 0f;

        foreach (var bloque in bloques)
        {
            acumulado += bloque.probabilidad;
            if (random <= acumulado)
                return bloque.prefab;
        }

        return bloques[0].prefab;
    }
}
