using System;
using UnityEngine;

namespace AngelWayOfSalvation.Core.Input
{
    public class InputManager : MonoBehaviour
    {
        public static InputManager Instance;

        public Vector2 InputMove { get; private set; }
        
        private Controls _controls;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this as InputManager;
                DontDestroyOnLoad(gameObject);
                return;
            }
            Destroy(Instance.gameObject);

            _controls = new Controls();
            _controls.Main.Jump.performed += context => Jump();
        }

        private void OnEnable()
        {
            if (_controls == null)
            {
                Debug.LogWarning("Controls are not initialized yet");
            }
            else
            {
                _controls.Enable();
            }
        }


        private void OnDisable() => _controls.Disable();

        private void Update()
        {
            float horizontal = _controls.Main.Horizontal.ReadValue<float>();
            float vertical = _controls.Main.Vertical.ReadValue<float>();

            InputMove = new Vector2(horizontal, vertical);
        }

        private void Jump()
        {
            Debug.Log("Jump - InputKeyboard");
        }

    }
}
