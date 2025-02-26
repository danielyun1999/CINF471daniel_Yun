using UnityEngine;

public abstract class CharacterState
{
    protected CharacterController character;

    public CharacterState(CharacterController character)
    {
        this.character = character;
    }

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
}
