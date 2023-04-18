using UnityEngine;

[CreateAssetMenu(menuName = "Character/CharacterData", fileName = "CharacterData")]
public class CharacterData : ScriptableObject
{
    [SerializeField] private byte _walkSpeed;
    [SerializeField] private byte _runSpeed;
    [SerializeField] private byte _health;

    public float GetWalkSpeed() => _walkSpeed;
    public float GetRunSpeed() => _walkSpeed;
    public byte GetHealth() => _health;
}
