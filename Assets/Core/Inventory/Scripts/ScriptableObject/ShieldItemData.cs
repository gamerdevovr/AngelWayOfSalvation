using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/ShieldItemData", fileName = "ShieldItemData")]
public class ShieldItemData : ItemData
{
    [SerializeField] private int _protection;

    public int GetProtection() => _protection;
}
