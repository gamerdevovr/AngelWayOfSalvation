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
        throw new System.NotImplementedException();
    }

    public void UpdateState(GameObject gameObject)
    {
        throw new System.NotImplementedException();
    }
}
