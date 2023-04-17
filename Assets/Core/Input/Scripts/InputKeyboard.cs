using System;
using UnityEngine;

namespace AngelWayOfSalvation.Core.Input
{
    public class InputKeyboard : MonoBehaviour
    {
        public Vector2 InputVector { get; private set; }

        public event Action JumpPressedInputKeyboard;

        private Controls _controls;


        private void Awake()
        {
            _controls = new Controls();
            _controls.Main.Jump.performed += context => Jump();
        }
        private void OnEnable() => _controls.Enable();
        private void OnDisable() => _controls.Disable();

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            float horizontal = _controls.Main.Horizontal.ReadValue<float>();
            float vertical = _controls.Main.Vertical.ReadValue<float>();

            InputVector = new Vector2(horizontal, vertical);
        }

        private void  Jump()
        {
            Debug.Log("Jump - InputKeyboard");

            JumpPressedInputKeyboard?.Invoke();
        }
    }
}
