using AngelWayOfSalvation.Core.Input;
using UnityEngine;

namespace AngelWayOfSalvation.Core.Character
{
    public class CharacterController : MonoBehaviour
    {
        private InputManager _inputManager => InputManager.Instance;
        private Character _character;

        private void Start()
        {
            _character = GetComponent<Character>();

            _inputManager.EventWalk += Walk;
            _inputManager.EventJump += Jump;
            _inputManager.EventAttack += Attack;
        }

        private void Walk() => _character.SetWalkState();
        private void Jump() => _character.SetJumpState();
        private void Attack() => _character.SetWalkState();
    }
}
