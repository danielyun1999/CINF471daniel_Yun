using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    private GameManager gameManager;
    private bool isDead = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player")?.transform;

       
        gameManager = FindFirstObjectByType<GameManager>(); 
    }

    void Update()
    {
        if (player != null)
        {
            agent.SetDestination(player.position);
        }
    }

    public void TakeDamage()
    {
        if (isDead) return;
        isDead = true;
        Die();
    }

    void Die()
    {
        if (gameManager != null)
        {
            gameManager.EnemyDefeated();
        }
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            TakeDamage();
            Destroy(other.gameObject);
        }
    }
}
