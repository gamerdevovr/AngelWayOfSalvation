using System;
using UnityEngine;

namespace AngelWayOfSalvation.Core.Input
{
    public class InputManager : MonoBehaviour
    {
        public static InputManager Instance;
        
        public event Action EventWalk;
        public event Action EventInRun;
        public event Action EventOutRun;
        public event Action EventJump;
        public event Action EventAttack;
        public event Action EventPray;
        public event Action EventIdle;

        public Vector2 InputMove { get; private set; }
        
        private Controls _controls;

        private void Awake()
        {
            _controls = new Controls();

            _controls.Main.Move.performed += context => Walk();
            _controls.Main.Move.canceled += context => Idle();
            _controls.Main.Run.performed += context => InRun();
            _controls.Main.Run.canceled += context => OutRun();
            _controls.Main.Jump.performed += context => Jump();
            _controls.Main.Attack.performed += context => Attack();
            _controls.Main.Pray.performed += context => Pray();

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
        private void Idle() => EventIdle?.Invoke();
        private void InRun() => EventInRun?.Invoke();
        private void OutRun() => EventOutRun?.Invoke();
        private void Jump() => EventJump?.Invoke();
        private void Attack() => EventAttack?.Invoke();
        private void Pray() => EventPray?.Invoke();

    }
}
