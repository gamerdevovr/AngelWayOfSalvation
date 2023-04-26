using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/SwordItemData", fileName = "SwordItemData")]
public class SwordItemData : ItemData
{
    [SerializeField] private int _damage;

    public int GetAttack() => _damage;
}
