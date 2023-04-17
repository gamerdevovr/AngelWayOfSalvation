using AngelWayOfSalvation.Core.Input;
using UnityEngine;

namespace AngelWayOfSalvation.Core.Character
{
    public class CharacterController : MonoBehaviour
    {
        private Character _character;
        private InputManager _inputManager => InputManager.Instance;

        private void Start()
        {
            _character = GetComponent<Character>();
        }

        private void OnEnable()
        {
            _inputManager.JumpPressedInputManager += Jump;
        }

        private void Update()
        {
            Debug.Log(_inputManager.GetDirectionMove());
        }

        private void Jump()
        {
            Debug.Log("Jump - CharacterController");
        }
    }
}
