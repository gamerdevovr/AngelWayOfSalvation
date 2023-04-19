using AngelWayOfSalvation.Core.Character;
using System.Collections;
using UnityEngine;

public class AttackState : ICharacterState
{
    private Character _character;

    public AttackState(Character character)
    {
        _character = character;
    }

    public void Enter()
    {
        Debug.Log("Enter Attack State");

        _character.SetState(CharacterStateType.Idle);
    }

    public void Exit()
    {
        //Debug.Log("Exit Attack State");
    }

    public void UpdateState()
    {
        //Debug.Log("Update Attack State");
    }
}
