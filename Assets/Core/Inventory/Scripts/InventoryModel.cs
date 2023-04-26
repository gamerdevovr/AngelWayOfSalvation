using System.Collections.Generic;
using UnityEngine;

namespace AngelWayOfSalvation.Core.Inventory
{
    public class InventoryModel : MonoBehaviour
    {
        private List<ItemData> _itemList = new List<ItemData>();

        public void AddItem(ItemData item) => _itemList.Add(item);
        public void RemoveItem(ItemData item) => _itemList.Remove(item);
        public List<ItemData> GetItemList() => _itemList;
    }
}