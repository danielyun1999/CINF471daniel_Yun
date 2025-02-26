using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 spawnPoint;

    void Start()
    {
        spawnPoint = transform.position; 
    }

    void Update()
    {
        if (transform.position.y < -5) 
        {
            transform.position = spawnPoint; 
            GetComponent<Rigidbody>().linearVelocity = Vector3.zero; 
        }
    }
}
