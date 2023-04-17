using AngelWayOfSalvation.Core.Character;
using UnityEngine;

public class WalkState : ICharacterState
{
    public void Enter()
    {
        Debug.Log("Enter Walk State");
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
