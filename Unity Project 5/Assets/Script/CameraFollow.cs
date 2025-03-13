using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; 
    public Vector3 offset = new Vector3(0, 1.5f, -5); 

    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player").transform;
        }
    }

    void LateUpdate()
    {
        if (player != null)
        {
            transform.position = player.position + offset; 
            transform.LookAt(player); 
        }
    }
}
