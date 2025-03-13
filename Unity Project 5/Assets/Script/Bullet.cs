using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float lifetime = 3f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.linearVelocity = transform.forward * speed;
        }

        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("💥 Bullet hit Enemy! Instant kill.");
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                Debug.Log("✅ Bullet dealing damage!");
                enemy.TakeDamage();
            }
            else
            {
                Debug.LogError("❌ Enemy script not found on hit object!");
            }

            Destroy(gameObject);
        }
    }
}
