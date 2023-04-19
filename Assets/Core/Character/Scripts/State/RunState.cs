using AngelWayOfSalvation.Core.Character;
using AngelWayOfSalvation.Core.Input;
using UnityEngine;

public class RunState : ICharacterState
{
    private InputManager _inputManager => InputManager.Instance;
    private Character _character;
    private Rigidbody _rigidbody;
    private float _speed;
    private Collision _collision;

    public RunState(Character character)
    {
        _character = character;
        _rigidbody = character.GetComponent<Rigidbody>();
        _speed = character.GetCharacterData().GetWalkSpeed();
        _collision = _character.Collision;
    }

    public void Enter()
    {
        //Debug.Log("Enter Walk State");
    }

    public void Exit()
    {
        //Debug.Log("Exit Walk State");
    }

    public void UpdateState()
    {
        //Debug.Log("Update Walk State");
        if (_collision != null)
        {
            Vector3 direction = GetDirection();
            Vector3 normal = GetNormal();

            RotateCharacter(direction);

            Vector3 directionMove = Vector3.ProjectOnPlane(direction, normal).normalized;
            Vector3 offset = directionMove * _speed * Time.deltaTime;

            _rigidbody.MovePosition(_rigidbody.position + offset);
        }
    }

    private Vector3 GetDirection()
    {
        float x = _inputManager.InputMove.x;
        float z = _inputManager.InputMove.y;

        return new Vector3(x, 0f, z);
    }

    private Vector3 GetNormal()
    {
        if (_collision.transform.CompareTag("Ground"))
        {
            return _collision.contacts[0].normal;
        }

        return Vector3.zero;
    }

    private void RotateCharacter(Vector3 direction)
    {
        float angle = Vector3.Angle(Vector3.forward, direction);

        if (angle >= 1f || angle == 0)
        {
            _character.transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}
