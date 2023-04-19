using AngelWayOfSalvation.Core.Character;
using UnityEngine;

public class PrayState : ICharacterState
{
    private Character _character;

    public PrayState(Character character)
    {
        _character = character;
    }

    public void Enter()
    {
        //Debug.Log("Enter Pray State");

        _character.SetState(CharacterStateType.Idle);
    }

    public void Exit()
    {
        //Debug.Log("Exit Pray State");
    }

    public void UpdateState()
    {
        //Debug.Log("Update Pray State");
    }
}
