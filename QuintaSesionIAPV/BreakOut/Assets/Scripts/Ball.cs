using UnityEngine;
using System.Collections;
public class Ball : MonoBehaviour
{
    private const float speedIncrement = 0.5f;
    private const float speedIncrementRate = 15.0f;
    // Use this for initialization
    void Start()
    {
        RestartBall();
        StartCoroutine(IncreaseSpeed());
    }
    // Update is called once per frame
    void Update()
    {
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Die")
        {
            RestartBall();
            UIManager.instance.LoseLife();
        }
    }
    void RestartBall()
    {
        transform.position = new Vector3(0.0f, 0.25f, 0.0f);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().AddForce(-Random.Range(1.0f, 2.5f), 0.0f, -Random.Range(1.0f, 2.5f), ForceMode.Impulse);
    }
    IEnumerator IncreaseSpeed()
    {
        while (true)
        {
            GetComponent<Rigidbody>().AddForce(GetComponent<Rigidbody>().velocity.normalized * speedIncrement, ForceMode.Impulse);
            yield return new WaitForSeconds(speedIncrementRate);
        }
    }
}
