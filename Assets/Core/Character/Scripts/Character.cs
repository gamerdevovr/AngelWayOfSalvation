using AngelWayOfSalvation.Core.Input;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace AngelWayOfSalvation.Core.Character
{
    [RequireComponent(typeof(Rigidbody))]
    public class Character : MonoBehaviour
    {
        [SerializeField] private CharacterData _characterData;

        public Vector3 Direction { get; private set; }

        private InputManager _inputManager => InputManager.Instance;
        private Rigidbody _rigidbody;
        private Collision _collision;
        private Vector3 _normal;

        private Dictionary<Type, ICharacterState> _stateMap;
        private ICharacterState _characterState;


        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            InitState();
            SetStateByDefault();
        }

        private void Update()
        {
            Direction = _inputManager.GetDirectionMove();

            if (_characterState != null)
            {
                _characterState.UpdateState(gameObject);
            }
        }

        private void InitState()
        {
            _stateMap = new Dictionary<Type, ICharacterState>();

            _stateMap[typeof(IdleState)] = new IdleState();
            _stateMap[typeof(WalkState)] = new WalkState();
            _stateMap[typeof(RunState)] = new RunState();
            _stateMap[typeof(AttackState)] = new AttackState();
            _stateMap[typeof(PrayState)] = new PrayState();
        }

        private void SetState(ICharacterState newState)
        {
            if (_characterState != null)
            {
                _characterState.Exit();
            }

            _characterState = newState;
            _characterState.Enter();
        }

        private ICharacterState GetState<T>() where T : ICharacterState
        {
            var type = typeof(T);
            return _stateMap[type];
        }

        private void SetStateByDefault()
        {
            var stateByDefault = GetState<IdleState>();
            SetState(stateByDefault);
        }

        private void OnCollisionEnter(Collision collision)
        {
            _collision = collision;
            
            if (collision.transform.CompareTag("Ground"))
            {
                _normal = collision.contacts[0].normal;
            }
        }

        private void OnCollisionExit (Collision collision)
        {
            _collision = null;
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.white;
            Gizmos.DrawLine(transform.position, transform.position + _normal * 3);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + (transform.forward * 2) - Vector3.Dot(transform.forward, _normal) * _normal);
        }
#endif
    }
}
