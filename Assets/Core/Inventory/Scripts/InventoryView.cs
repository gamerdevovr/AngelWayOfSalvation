using UnityEngine;
using System.Collections.Generic;
using AngelWayOfSalvation.Core.Inventory;

public class InventoryView : MonoBehaviour
{
    private InventoryModel _inventoryModel;
    private GameObject _inventoryItemPrefab;
    private Transform _inventoryList;

    public void UpdateInventoryList()
    {
        foreach (Transform child in _inventoryList)
        {
            Destroy(child.gameObject);
        }

        List<ItemData> itemList = _inventoryModel.GetItemList();
        foreach (ItemData item in itemList)
        {
            GameObject newItem = Instantiate(_inventoryItemPrefab, _inventoryList);
            InventoryItemUI itemUI = newItem.GetComponent<InventoryItemUI>();
            itemUI.SetItem(item);
        }
    }

    public void AddItemToInventroy(ItemData item)
    {
        _inventoryModel.AddItem(item);
        UpdateInventoryList();
    }

    public void RemoveItemFromInventory(ItemData item)
    {
        _inventoryModel.RemoveItem(item);
        UpdateInventoryList();
    }
}
