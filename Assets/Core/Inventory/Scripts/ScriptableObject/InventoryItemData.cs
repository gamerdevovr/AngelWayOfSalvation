using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/InventoryItemData", fileName = "InventoryItemData")]
public class InventoryItemData : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private int _price;
    [SerializeField] private float _weight;
    [SerializeField] private float _damage;

    public string GetItemName() => _name;
    public string GetDescription() => _description;
    public Sprite GetSprite() => _sprite;
    public int GetPrice() => _price;
    public float GetWeight() => _weight;
    public float GetDamage() => _damage;
}
