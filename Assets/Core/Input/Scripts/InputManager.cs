using System;
using UnityEngine;

namespace AngelWayOfSalvation.Core.Input
{
    public class InputManager : MonoBehaviour
    {
        public static InputManager Instance;
        
        public event Action EventWalk;
        public event Action EventJump;
        public event Action EventAttack;

        public Vector2 InputMove { get; private set; }
        
        private Controls _controls;

        private void Awake()
        {
            _controls = new Controls();

            _controls.Main.Move.performed += context => Walk();
            _controls.Main.Jump.performed += context => Jump();
            _controls.Main.Attack.performed += context => Attack();

            if (Instance == null)
            {
                Instance = this as InputManager;
                DontDestroyOnLoad(gameObject);
                return;
            }
            Destroy(Instance.gameObject);
        }

        private void Update()
        {
            InputMove = _controls.Main.Move.ReadValue<Vector2>();
        }

        private void OnEnable() => _controls.Enable();
        private void OnDisable() => _controls.Disable();
        private void Walk() => EventWalk?.Invoke();
        private void Jump() => EventJump?.Invoke();
        private void Attack() => EventAttack?.Invoke();

    }
}
