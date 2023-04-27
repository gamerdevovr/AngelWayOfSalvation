using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<ItemData> _items;
    [SerializeField] private InventoryItemUI _inventoryItemUI;
    [SerializeField] private Transform _container;

    public void OnEnable()
    {
        Render(_items);
    }

    public void Render(List<ItemData> items)
    {
        foreach (Transform child in _container)
        {
            Destroy(child.gameObject);
        }
        
        items.ForEach(item =>
        {
            var cell = Instantiate(_inventoryItemUI, _container);
            cell.SetItem(item);
        });
    }
}
