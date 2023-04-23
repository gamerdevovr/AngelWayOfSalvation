using UnityEngine;

[CreateAssetMenu(menuName = "Character/CharacterData", fileName = "CharacterData")]
public class CharacterData : ScriptableObject
{
    [SerializeField] private byte _walkSpeed;
    [SerializeField] private byte _runSpeed;
    [SerializeField] private byte _jumpForse;
    [SerializeField] private byte _health;

    public byte GetWalkSpeed() => _walkSpeed;
    public byte GetRunSpeed() => _runSpeed;
    public byte GetJumpForse() => _jumpForse;
    public byte GetHealth() => _health;
}
