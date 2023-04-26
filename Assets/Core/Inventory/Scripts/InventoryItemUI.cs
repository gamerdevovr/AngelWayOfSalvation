using UnityEngine;
using UnityEngine.UI;

public class InventoryItemUI : MonoBehaviour
{
    [SerializeField] private Image _itemImage;
    [SerializeField] private Text _itemName;
    [SerializeField] private int _itemWeight;

    public void SetItem(ItemData item)
    {
        _itemImage.sprite = item.GetSprite();
        _itemName.text = item.GetItemName();
        _itemWeight = item.GetWeight();
    }
}
