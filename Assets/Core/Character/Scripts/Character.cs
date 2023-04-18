using UnityEngine;

namespace AngelWayOfSalvation.Core.Character
{
    [RequireComponent(typeof(Rigidbody))]
    public class Character : MonoBehaviour
    {
        [SerializeField] private CharacterData _characterData;
        public Vector3 Normal { get; private set; }

        private Collision _collision;
        private ICharacterState _characterState;
        private IdleState _idleState;
        private WalkState _walkState;
        private RunState _runState;
        private JumpState _jumpState;
        private AttackState _attackState;
        private PrayState _prayState;

        public void SetIdleState() => SetState(_idleState);
        public void SetWalkState() => SetState(_walkState);
        public void SetRunState() => SetState(_runState);
        public void SetJumpState() => SetState(_runState);
        public void SetAttackState() => SetState(_attackState);
        public void SetPrayState() => SetState(_prayState);
        public float GetWalkSpeed() => _characterData.GetWalkSpeed();
        public float GetRunSpeed() => _characterData.GetRunSpeed();

        private void Start()
        {
            _idleState = new IdleState();
            _walkState = new WalkState(this);
            _runState = new RunState(this);
            _attackState = new AttackState();
            _prayState = new PrayState();

            SetState(_idleState);
        }

        private void Update()
        {
            _characterState.UpdateState();
        }


        private void SetState(ICharacterState newState)
        {
            if (_characterState == newState)
            {
                return;
            }

            if (_characterState != null)
            {
                _characterState.Exit();
            }

            _characterState = newState;
            _characterState.Enter();
        }

        private void OnCollisionEnter(Collision collision)
        {
            _collision = collision;
            
            if (collision.transform.CompareTag("Ground"))
            {
                Normal = collision.contacts[0].normal;
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
            Gizmos.DrawLine(transform.position, transform.position + Normal * 3);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + (transform.forward * 2) - Vector3.Dot(transform.forward, Normal) * Normal);
        }
#endif
    }
}
