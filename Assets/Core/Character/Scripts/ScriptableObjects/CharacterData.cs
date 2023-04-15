using UnityEngine;

[CreateAssetMenu(menuName = "Character/CharacterData", fileName = "CharacterData")]
public class CharacterData : ScriptableObject
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private byte _health;

    public float GetMoveSpeed => _moveSpeed;
    public byte GetHealth => _health;
}
