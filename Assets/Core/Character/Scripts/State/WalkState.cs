using AngelWayOfSalvation.Core.Character;
using AngelWayOfSalvation.Core.Input;
using UnityEngine;

public class WalkState : ICharacterState
{
    private InputManager _inputManager => InputManager.Instance;
    private Character _character;
    private Rigidbody _rigidbody;
    private float _speed;

    public WalkState(Character character)
    {
        _character = character;
        _rigidbody = character.GetComponent<Rigidbody>();
        _speed = character.GetCharacterData().GetWalkSpeed();
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

        Vector3 direction = new Vector3(_inputManager.InputMove.x, 0f, _inputManager.InputMove.y);
        Vector3 normal = _character.Normal;

        if (Vector3.Angle(Vector3.forward, direction) > 1f || Vector3.Angle(Vector3.forward, direction) == 0)
        {
            Vector3 direct = Vector3.RotateTowards(_character.transform.forward, direction, _speed, 0f);
            _character.transform.rotation = Quaternion.LookRotation(direct);
        }

        Vector3 directionMove = direction.normalized - Vector3.Dot(direction.normalized, normal) * normal;
        Vector3 offset = directionMove * _speed * Time.deltaTime;

        _rigidbody.MovePosition(_rigidbody.position + offset);

    }
}
