using UnityEngine;
using UnityEngine.Serialization;

public class OpenDoor : MonoBehaviour
{
    public Transform targetTransform;
    private Vector3 _oldPosition;
    private Vector3 _targetPosition;
    public float duration;
    private float _timeElapsed;

    private bool _thisOpening = false;
    private bool _alreadyOpened = false;

    void Start()
    {
        _oldPosition = transform.position;
        _targetPosition = targetTransform.position;
    }

    void Update()
    {
        if (_alreadyOpened) { return; }

        if (_thisOpening)
        {
            MoveToTarget();
        }

        if (transform.position == _targetPosition)
        {
            _thisOpening = false;
            _alreadyOpened = true;
        }
    }

    private void MoveToTarget()
    {
        if (_timeElapsed < duration)
        {
            transform.position = Vector3.Lerp(_oldPosition, _targetPosition, _timeElapsed / duration);
            _timeElapsed += Time.deltaTime;
        }
        else
        {
            transform.position = _targetPosition;
        }
    }

    public void Open()
    {
        _thisOpening = true;
    }
}