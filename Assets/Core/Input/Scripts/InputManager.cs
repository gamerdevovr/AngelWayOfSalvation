using System;
using UnityEngine;

namespace AngelWayOfSalvation.Core.Input
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private InputJoystick _inputJoystick;
        [SerializeField] private InputKeyboard _inputKeyboard;

        public static InputManager Instance;

        public Vector3 _directionMove = new Vector3(0, 0, 0);

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this as InputManager;
                DontDestroyOnLoad(gameObject);
                return;
            }
                
            Destroy(Instance.gameObject);
        }

        public Vector3 GetDirectionMove()
        {
            if (_inputJoystick.InputVector.x != 0 || _inputJoystick.InputVector.y != 0)
            {
                _directionMove = new Vector3(_inputJoystick.InputVector.x, 0, _inputJoystick.InputVector.y);
            }
            else if (_inputKeyboard.InputVector.x != 0 || _inputKeyboard.InputVector.y != 0)
            {
                _directionMove = new Vector3(_inputKeyboard.InputVector.x, 0, _inputKeyboard.InputVector.y);
            }
            else
            {
                _directionMove = Vector3.zero;
            }

            return _directionMove;
        }
    }
}
