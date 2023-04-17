using AngelWayOfSalvation.Core.Character;
using UnityEngine;

public class AttackState : ICharacterState
{
    public void Enter()
    {
        Debug.Log("Enter Attack State");
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
