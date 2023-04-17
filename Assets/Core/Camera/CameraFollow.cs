using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float _lerpSpeed = 0.05f;
    [SerializeField] private Vector3 _offsetPosition;
    [SerializeField] private Vector3 _offsetRotation;
    [SerializeField] private Transform _targetTransform;

    [SerializeField] private bool _calibrateMode;


    public void SetTarget(Transform target)
    {
        _targetTransform = target;
        transform.rotation = Quaternion.Euler(_offsetRotation);
    }

    private void FixedUpdate()
    {
        if (_targetTransform)
        {
            Vector3 newCamPosition = _targetTransform.position + _offsetPosition;
            transform.position = Vector3.Lerp(transform.position, newCamPosition, _lerpSpeed);

            if (_calibrateMode)
            {
                transform.rotation = Quaternion.Euler(_offsetRotation);
            }
        }
    }
}
