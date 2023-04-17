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
        Debug.Log("Exit Walk State");
    }

    public void UpdateState(GameObject gameObject)
    {
        Debug.Log("Update Walk State");
    }
}
