using System.Collections.Generic;
using UnityEngine;

namespace AngelWayOfSalvation.Core.Character
{
    [RequireComponent(typeof(Rigidbody))]
    public class Character : MonoBehaviour
    {
        [SerializeField] private CharacterData _characterData;

        public Vector3 Normal { get; private set; }
        public Collision _collision { get; private set; }

        private ICharacterState _characterState;
        private Dictionary<CharacterStateType, ICharacterState> _states;

        public CharacterData GetCharacterData() => _characterData;

        public void SetState(CharacterStateType stateType)
        {
            if (_characterState != null)
            {
                _characterState.Exit();
            }

            _states.TryGetValue(stateType, out _characterState);
            _characterState?.Enter();
        }


        private void Start()
        {
            _states = new Dictionary<CharacterStateType, ICharacterState>()
            {
                { CharacterStateType.Idle, new IdleState(this) },
                { CharacterStateType.Walk, new WalkState(this) },
                { CharacterStateType.Run, new RunState(this) },
                { CharacterStateType.Jump, new JumpState(this) },
                { CharacterStateType.Attack, new AttackState(this) },
                { CharacterStateType.Pray, new PrayState(this) }
            };

            SetState(CharacterStateType.Idle);
        }

        private void Update()
        {
            _characterState.UpdateState();
        }

        private void OnCollisionEnter(Collision collision)
        {
            _collision = collision;

            if (collision.transform.CompareTag("Ground"))
            {
                Normal = collision.contacts[0].normal;
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            _collision = null;
        }
    }
}
