using System;
using UnityEngine;

namespace AngelWayOfSalvation.Core.Input
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private InputJoystick _inputJoystick;
        [SerializeField] private InputKeyboard _inputKeyboard;

        public static InputManager Instance;

        public event Action JumpPressedInputManager;

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

        private void OnEnable()
        {
            _inputKeyboard.JumpPressedInputKeyboard += PressedJump;
        }

        public void PressedJump()
        {
            Debug.Log("Jump - InputManager");
            JumpPressedInputManager?.Invoke();
        }

        public Vector3 GetDirectionMove()
        {
            Vector3 directionMove = new Vector3(0, 0, 0);

            if (_inputJoystick.InputVector.x != 0 || _inputJoystick.InputVector.y != 0)
            {
                directionMove = new Vector3(_inputJoystick.InputVector.x, 0, _inputJoystick.InputVector.y);
            }
            else if (_inputKeyboard.InputVector.x != 0 || _inputKeyboard.InputVector.y != 0)
            {
                directionMove = new Vector3(_inputKeyboard.InputVector.x, 0, _inputKeyboard.InputVector.y);
            }

            return directionMove;
        }
    }
}
