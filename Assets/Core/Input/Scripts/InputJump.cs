using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class InputJump : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private Image _image;
    private bool _stateBnt = false;

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        _stateBnt = true;
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        _stateBnt = false;
    }

    public bool GetState()
    {
        return _stateBnt;
    }

    private void Start()
    {
        _image = GetComponent<Image>();
    }
}
