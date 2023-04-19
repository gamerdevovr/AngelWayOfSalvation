using AngelWayOfSalvation.Core.Character;
using AngelWayOfSalvation.Core.Input;
using UnityEngine;

public class JumpState : ICharacterState
{
    private InputManager _inputManager => InputManager.Instance;
    private Character _character;
    private Rigidbody _rigidbody;
    private float _forceJump;

    public JumpState(Character character)
    {
        _character = character;
        _rigidbody = character.GetComponent<Rigidbody>();
        _forceJump = _character.GetCharacterData().GetJumpForse();
    }

    public void Enter()
    {
        //Debug.Log("Enter Jump State");
        Vector3 direction = new Vector3(_inputManager.InputMove.x, 0f, _inputManager.InputMove.y);

        Vector3 jumpDirection = (direction + Vector3.up).normalized * _forceJump;

        _rigidbody.AddForce(jumpDirection, ForceMode.Impulse);

        _character.SetState(CharacterStateType.Idle);
    }

    public void Exit()
    {
        //Debug.Log("Exit Jump State");
    }

    public void UpdateState()
    {
        //Debug.Log("Update Jump State");
    }
}
