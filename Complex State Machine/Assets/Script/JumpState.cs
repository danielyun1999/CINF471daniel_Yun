using UnityEngine;

public class JumpState : CharacterState
{
    public JumpState(CharacterController character) : base(character) { }

    public override void EnterState()
    {
        
        character.GetComponent<Rigidbody>().AddForce(Vector3.up * 10, ForceMode.Impulse); 
    }

    public override void UpdateState()
    {
        if (character.IsGrounded())
        {
            character.SwitchState(new IdleState(character));
        }
    }

    public override void ExitState()
    {
       
    }
}
