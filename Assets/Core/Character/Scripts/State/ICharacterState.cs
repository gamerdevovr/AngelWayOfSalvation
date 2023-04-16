using UnityEngine;

namespace AngelWayOfSalvation.Core.Character
{
    public interface ICharacterState
    {
        void Enter();
        void Exit();
        void UpdateState();
    }
}
