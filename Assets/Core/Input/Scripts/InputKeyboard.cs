using UnityEngine;

namespace AngelWayOfSalvation.Core.Input
{
    public class InputKeyboard : MonoBehaviour
    {
        public Vector2 InputVector { get; private set; }

        private Controls _controls;

        private void Awake() => _controls = new Controls();
        private void OnEnable() => _controls.Enable();
        private void OnDisable() => _controls.Disable();

        private void Update()
        {
            float horizontal = _controls.Main.Horizontal.ReadValue<float>();
            float vertical = _controls.Main.Vertical.ReadValue<float>();

            InputVector = new Vector2(horizontal, vertical);
        }

    }
}
