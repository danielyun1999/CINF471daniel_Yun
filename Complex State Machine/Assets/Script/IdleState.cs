using UnityEngine;

public class IdleState : CharacterState
{
    public IdleState(CharacterController character) : base(character) { }

    public override void EnterState()
    {
     
    }

    public override void UpdateState()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            character.SwitchState(new MoveState(character));
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            character.SwitchState(new JumpState(character));
        }
    }

    public override void ExitState()
    {
       
    }
}
