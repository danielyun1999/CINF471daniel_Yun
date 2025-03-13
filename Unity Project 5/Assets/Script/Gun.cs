using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 20f;
    public AudioClip gunShotSound;
    private AudioSource audioSource;
    private PlayerInput playerInput;

    void Start()
    {
        playerInput = FindFirstObjectByType<PlayerInput>();
        audioSource = GetComponent<AudioSource>();

        if (playerInput != null)
        {
            playerInput.actions["Fire"].performed += ctx => OnFire();
        }
    }

    void OnFire()
    {
        if (gunShotSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(gunShotSound);
        }

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.linearVelocity = firePoint.forward * bulletSpeed;
        }
    }
}
