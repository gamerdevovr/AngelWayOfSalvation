using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace AngelWayOfSalvation.Core.Input
{
    public class InputJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
    {
        [SerializeField] private float _scaleInputVector = 2f;
        [SerializeField] private Image _inputJoystick;
        [SerializeField] private Image _buttonJoystick;

        public Vector2 InputVector { get; private set; }

        private void Start()
        {
            _inputJoystick = GetComponent<Image>();
            _buttonJoystick = transform.GetChild(0).GetComponent<Image>();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            InputVector = Vector2.zero;
            _buttonJoystick.rectTransform.anchoredPosition = Vector2.zero;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            OnDrag(eventData);
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector2 position;

            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_inputJoystick.rectTransform, eventData.position, eventData.pressEventCamera, out position))
            {
                position.x /= _inputJoystick.rectTransform.sizeDelta.x;
                position.y /= _inputJoystick.rectTransform.sizeDelta.y;

                float inputX = position.x * _scaleInputVector;
                float inputY = position.y * _scaleInputVector;
                InputVector = new Vector2(inputX, inputY);
                InputVector = (InputVector.magnitude > 1.0f) ? InputVector.normalized : InputVector;

                float anchoredPosX = InputVector.x * (_inputJoystick.rectTransform.sizeDelta.x / _scaleInputVector);
                float anchoredPosY = InputVector.y * (_inputJoystick.rectTransform.sizeDelta.y / _scaleInputVector);
                _buttonJoystick.rectTransform.anchoredPosition = new Vector2(anchoredPosX, anchoredPosY);
            }
        }
    }
}
