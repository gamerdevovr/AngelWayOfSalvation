using AngelWayOfSalvation.Core.Character;
using UnityEngine;

public class PrayState : ICharacterState
{
    public void Enter()
    {
        Debug.Log("Enter Pray State");
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
