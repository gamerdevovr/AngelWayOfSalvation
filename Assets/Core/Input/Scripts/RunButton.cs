using AngelWayOfSalvation.Core.Input;
using UnityEngine;
using UnityEngine.UI;

public class RunButton : MonoBehaviour
{
    private InputManager _inputManager => InputManager.Instance;

    private Image _image;
    private Color _color;

    private void Start()
    {
        _image = GetComponent<Image>();
        _color = _image.color;
        
        _color.a = 0.5f;
        _image.color = _color;

        _inputManager.EventOutRun += SetWalk;
        _inputManager.EventInRun += SetRun;
    }

    private void SetWalk()
    {
        _color.a = 0.5f;
        _image.color = _color;
    }

    private void SetRun()
    {
        _color.a = 1f;
        _image.color = _color;
    }
}
