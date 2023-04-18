using AngelWayOfSalvation.Core.Input;
using UnityEngine;

namespace AngelWayOfSalvation.Core.Character
{
    public class CharacterController : MonoBehaviour
    {
        private InputManager _inputManager => InputManager.Instance;
        private Character _character;
        private Vector2 _zeroVector2 = new Vector2(0, 0);

        private void Start()
        {
            _character = GetComponent<Character>();

            _inputManager.EventWalk += Walk;
            _inputManager.EventJump += Walk;
            _inputManager.EventWalk += Walk;
        }

        private void Update()
        {
            //Debug.Log(_inputManager.InputMove);
            //if (_inputManager.InputMove == _zeroVector2)
            //{
            //    _character.SetIdleState();
            //}
            //else
            //{
            //    _character.SetWalkState();
            //}
        }

        private void Walk() => _character.SetWalkState();
        private void Jump() => _character.SetJumpState();
        private void Attack() => _character.SetWalkState();
    }
}
