using AngelWayOfSalvation.Core.Character;
using UnityEngine;

public class IdleState : ICharacterState
{

    public void Enter()
    {
        Debug.Log("Enter Idle State");
    }

    public void Exit()
    {
        Debug.Log("Exit Idle State");
    }

    public void UpdateState()
    {
        Debug.Log("Update Idle State");
    }
}
