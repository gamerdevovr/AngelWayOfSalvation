using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryItemUI : MonoBehaviour
{
    private Image _itemSprite;
    private TextMeshProUGUI _itemLevel;
    private int _itemWeight;

    private void Awake()
    {
        _itemSprite = GetComponent<Image>();
        _itemLevel = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    public void SetItem(ItemData item)
    {
        _itemSprite.sprite = item.GetSprite();
        _itemLevel.text = item.GetLevel().ToString();
        _itemWeight = item.GetWeight();
    }
}
