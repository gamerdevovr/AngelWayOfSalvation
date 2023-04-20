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
            _inputManager.EventIdle += Idle;
            _inputManager.EventJump += Jump;
            _inputManager.EventAttack += Attack;
            _inputManager.EventPray += Pray;
        }

        private void Walk() => _character.SetState(CharacterStateType.Move);
        private void Idle() => _character.SetState(CharacterStateType.Idle);
        private void Jump() => _character.SetState(CharacterStateType.Jump);
        private void Attack() => _character.SetState(CharacterStateType.Attack);
        private void Pray() => _character.SetState(CharacterStateType.Pray);
    }
}
