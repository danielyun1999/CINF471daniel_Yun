using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private CharacterState currentState;
    public float speed = 5f;

    void Start()
    {
        currentState = new IdleState(this);
    }

    void Update()
    {
        currentState.UpdateState();
    }

    public void SwitchState(CharacterState newState)
    {
        currentState.ExitState();
        currentState = newState;
        currentState.EnterState();
    }

    public bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
}
