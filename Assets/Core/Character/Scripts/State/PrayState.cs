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
        Debug.Log("Exit Pray State");
    }

    public void UpdateState()
    {
        Debug.Log("Update Pray State");
    }
}
