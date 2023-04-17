using AngelWayOfSalvation.Core.Character;
using UnityEngine;

public class RunState : ICharacterState
{
    public void Enter()
    {
        Debug.Log("Enter Run State");
    }

    public void Exit()
    {
        Debug.Log("Exit Run State");
    }

    public void UpdateState(GameObject gameObject)
    {
        Debug.Log("Update Run State");

        //if (Vector3.Angle(Vector3.forward, direction) > 1f || Vector3.Angle(Vector3.forward, direction) == 0)
        //{
        //    Vector3 direct = Vector3.RotateTowards(gameObject.transform.forward, direction, _characterData.GetMoveSpeed, 0f);
        //    gameObject.transform.rotation = Quaternion.LookRotation(direct);
        //}

        //Vector3 directionMove = direction.normalized - Vector3.Dot(direction.normalized, _normal) * _normal;
        //Vector3 offset = directionMove * _characterData.GetMoveSpeed * Time.deltaTime;

        //_rigidbody.MovePosition(_rigidbody.position + offset);
    }
}
