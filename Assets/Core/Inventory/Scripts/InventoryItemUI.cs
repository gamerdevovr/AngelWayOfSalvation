using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class InventoryItemUI : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Image _itemImage;
    private TextMeshProUGUI _itemLevel;
    private int _itemWeight;
    private Transform _draggingParent;
    private Transform _originalParent;

    private void Awake()
    {
        _itemImage = GetComponent<Image>();
        _itemLevel = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    public void Init(Transform draggingParant)
    {
        _draggingParent = draggingParant;
        _originalParent = transform.parent;
    }

    public void SetItem(ItemData item)
    {
        _itemImage.sprite = item.GetSprite();
        _itemLevel.text = item.GetLevel().ToString();
        _itemWeight = item.GetWeight();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.parent = _draggingParent;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        int closestIndex = 0;

        for (int i = 0; i < _originalParent.childCount; i++)
        {
            float distance = Vector3.Distance(transform.position, _originalParent.GetChild(i).position);
            float distanceClosest = Vector3.Distance(transform.position, _originalParent.GetChild(closestIndex).position);

            if (distance < distanceClosest)
            {
                closestIndex = i;
            }
        }

        transform.parent = _originalParent;
        transform.SetSiblingIndex(closestIndex);
    }

}
