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

        private Rigidbody _rigidbody;
        private Collision _collision;
        private Vector3 _normal;

        private ICharacterState _characterState;
        private IdleState _idleState = new IdleState();
        private WalkState _walkState = new WalkState();
        private RunState _runState = new RunState();
        private AttackState _attackState = new AttackState();
        private PrayState _prayState = new PrayState();

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            SetState(_idleState);
        }

        private void Update()
        {
            _characterState.UpdateState(gameObject);
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

        public void SetIdleState()
        {
            SetState(_idleState);
        }

        public void SetWalkState()
        {
            SetState(_walkState);
        }

        public void SetRunState()
        {
            SetState(_runState);
        }

        public void SetAttackState()
        {
            SetState(_attackState);
        }

        public void SetPrayState()
        {
            SetState(_prayState);
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
