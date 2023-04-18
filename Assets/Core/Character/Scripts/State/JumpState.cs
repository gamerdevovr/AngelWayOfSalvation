using AngelWayOfSalvation.Core.Character;
using UnityEngine;

public class JumpState : ICharacterState
{
    public void Enter()
    {
        Debug.Log("Enter Run State");
    }

    public void Exit()
    {
        Debug.Log("Exit Run State");
    }

    public void UpdateState()
    {
        Debug.Log("Update Run State");
    }
}
