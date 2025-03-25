using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float forceValue;
    public float jumpForce; // Fuerza del salto
    private Rigidbody rb;
    private bool isGrounded = true; // Determina si la esfera est� en el suelo

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Comprueba si se presiona la barra espaciadora y si la esfera est� en el suelo
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false; // Se marca como no en suelo hasta que se vuelva a aterrizar
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(new Vector3(Input.GetAxis("Horizontal"),
                                0,
                                Input.GetAxis("Vertical")) * forceValue);
    }

    // Este m�todo se llama al comenzar una colisi�n
    private void OnCollisionEnter(Collision collision)
    {
        // Aseg�rate de que las plataformas (o el suelo) tengan el tag "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}