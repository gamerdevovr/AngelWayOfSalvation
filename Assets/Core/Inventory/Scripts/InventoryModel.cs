using System.Collections.Generic;
using UnityEngine;

namespace AngelWayOfSalvation.Core.Inventory
{
    public class InventoryModel : MonoBehaviour
    {
        private List<InventoryItemData> _itemList = new List<InventoryItemData>();

        public void AddItem(InventoryItemData item) => _itemList.Add(item);
        public void RemoveItem(InventoryItemData item) => _itemList.Remove(item);
        public List<InventoryItemData> GetItemList() => _itemList;
    }
}