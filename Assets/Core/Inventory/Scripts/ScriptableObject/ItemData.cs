using UnityEngine;

public abstract class ItemData : ScriptableObject
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] ItemType _type;
    [SerializeField] private string _name;
    [TextArea(15,20)]
    [SerializeField] private string _description;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private int _price;
    [SerializeField] private int _weight;

    public GameObject GetItemPrefab() => _prefab;
    public string GetItemName() => _name;
    public string GetDescription() => _description;
    public Sprite GetSprite() => _sprite;
    public int GetPrice() => _price;
    public int GetWeight() => _weight;
}