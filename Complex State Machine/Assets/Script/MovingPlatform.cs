using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 3f;
    public float distance = 5f;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float moveX = Mathf.PingPong(Time.time * speed, distance * 2) - distance;
        transform.position = new Vector3(startPosition.x + moveX, startPosition.y, startPosition.z);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
