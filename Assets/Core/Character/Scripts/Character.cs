using AngelWayOfSalvation.Core.Input;
using UnityEngine;

namespace AngelWayOfSalvation.Core.Character
{
    [RequireComponent(typeof(Rigidbody))]
    public class Character : MonoBehaviour
    {
        [SerializeField] private CharacterData _characterData;

        private InputManager _inputManager => InputManager.Instance;
        private Rigidbody _rigidbody;
        private Vector3 _normal;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            Vector3 direction = _inputManager.GetDirectionMove();
            Debug.Log(direction);

            if (Vector3.Angle(Vector3.forward, direction) > 1f || Vector3.Angle(Vector3.forward, direction) == 0)
            {
                Vector3 direct = Vector3.RotateTowards(transform.forward, direction, _characterData.GetMoveSpeed, 0f);
                transform.rotation = Quaternion.LookRotation(direct);
            }

            Vector3 directionMove = direction.normalized - Vector3.Dot(direction.normalized, _normal) * _normal;
            Vector3 offset = directionMove * _characterData.GetMoveSpeed * Time.deltaTime;

            _rigidbody.MovePosition(_rigidbody.position + offset);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.CompareTag("Ground"))
            {
                _normal = collision.contacts[0].normal;
            }
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
