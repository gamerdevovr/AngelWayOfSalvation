using UnityEngine;

namespace AngelWayOfSalvation.Core.Input
{
    public class InputManager : MonoBehaviour
    {
        public Vector3 DirectionMove { get; private set; } = new Vector3(0, 0, 0);

        [SerializeField] private InputJoystick _inputJoystick;
        [SerializeField] private InputKeyboard _inputKeyboard;


        private void Update()
        {
            if (_inputJoystick.InputVector.x != 0 || _inputJoystick.InputVector.y != 0)
            {
                DirectionMove = new Vector3(_inputJoystick.InputVector.x, 0, _inputJoystick.InputVector.y);
            }
            else if (_inputKeyboard.InputVector.x != 0 || _inputKeyboard.InputVector.y != 0)
            {
                DirectionMove = new Vector3(_inputKeyboard.InputVector.x, 0, _inputKeyboard.InputVector.y);
            }
        }
    }
}
