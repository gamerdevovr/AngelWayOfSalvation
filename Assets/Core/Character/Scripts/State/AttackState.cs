using AngelWayOfSalvation.Core.Character;
using UnityEngine;

public class AttackState : ICharacterState
{
    public AttackState(Character character)
    {

    }

    public void Enter()
    {
        //Debug.Log("Enter Attack State");
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
