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
        Debug.Log("Exit Attack State");
    }

    public void UpdateState(GameObject gameObject)
    {
        Debug.Log("Update Attack State");
    }
}
