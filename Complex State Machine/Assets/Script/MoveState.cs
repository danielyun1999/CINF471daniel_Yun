using UnityEngine;

public class MoveState : CharacterState
{
    public MoveState(CharacterController character) : base(character) { }

    public override void EnterState()
    {
        
    }

    public override void UpdateState()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        character.transform.Translate(move * Time.deltaTime * character.speed);

        if (move == Vector3.zero)
        {
            character.SwitchState(new IdleState(character));
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
