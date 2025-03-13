using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 movement;
    Vector2 mouseMovement;
    CharacterController controller;

    [SerializeField]
    float speed = 2.0f;

    [SerializeField]
    Camera cam;

    float cameraUpRotation = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        if (cam == null)
        {
            cam = Camera.main;
        }
    }

    void Update()
    {
        if (controller == null) return;

        float lookX = mouseMovement.x * Time.deltaTime * 100f;
        float lookY = mouseMovement.y * Time.deltaTime * 100f;
        cameraUpRotation -= lookY;
        cameraUpRotation = Mathf.Clamp(cameraUpRotation, -90f, 90f);
        cam.transform.localRotation = Quaternion.Euler(cameraUpRotation, 0, 0);

        transform.Rotate(Vector3.up * lookX);

        Vector3 moveDirection = transform.right * movement.x + transform.forward * movement.y;
        controller.Move(moveDirection * Time.deltaTime * speed);
    }

    void OnMove(InputValue moveVal)
    {
        movement = moveVal.Get<Vector2>();
    }

    void OnLook(InputValue lookVal)
    {
        mouseMovement = lookVal.Get<Vector2>();
    }
}
