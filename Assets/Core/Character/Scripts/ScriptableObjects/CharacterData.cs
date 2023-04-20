using UnityEngine;

[CreateAssetMenu(menuName = "Character/CharacterData", fileName = "CharacterData")]
public class CharacterData : ScriptableObject
{
    [SerializeField] private byte _walkSpeed;
    [SerializeField] private byte _runSpeed;
    [SerializeField] private byte _jumpForse;
    [SerializeField] private byte _health;

    public float GetWalkSpeed() => _walkSpeed;
    public float GetRunSpeed() => _runSpeed;
    public float GetJumpForse() => _jumpForse;
    public byte GetHealth() => _health;
}
