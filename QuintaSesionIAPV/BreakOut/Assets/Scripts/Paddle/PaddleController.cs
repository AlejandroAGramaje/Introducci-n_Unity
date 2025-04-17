using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public GameObject paddle1;
    public GameObject paddle2;

    public float speed = 3.0f;
    public float paddleOffsetX = 2.5f;

    private const float leftLimit = -4.5f;
    private const float rightLimit = 4.5f;

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal") * Time.deltaTime * speed;

        // Solo Paddle1 activa
        if (paddle2 == null || !paddle2.activeSelf)
        {
            Vector3 newPos = paddle1.transform.position + new Vector3(moveInput, 0, 0);
            newPos.x = Mathf.Clamp(newPos.x, leftLimit, rightLimit);
            paddle1.transform.position = newPos;
        }
        // Ambas paddles activas y sincronizadas con offset
        else
        {
            // Movemos paddle1
            Vector3 newPos1 = paddle1.transform.position + new Vector3(moveInput, 0, 0);

            // Calculamos dónde debería estar Paddle2
            Vector3 newPos2 = new Vector3(newPos1.x + paddleOffsetX, paddle1.transform.position.y, paddle1.transform.position.z);

            // Comprobamos límites
            if (newPos1.x < leftLimit || newPos1.x > rightLimit ||
                newPos2.x < leftLimit || newPos2.x > rightLimit)
                return;

            // Aplicamos posiciones
            paddle1.transform.position = newPos1;
            paddle2.transform.position = newPos2;
        }
    }
}
