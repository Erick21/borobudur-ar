using UnityEngine;

public class ZoomRotate : MonoBehaviour
{

    [Header("Zoom Settings")]
    [SerializeField] float _minSize = .25f;
    [SerializeField] float _maxSize = 1.5f;
    bool _isRotating;

    Vector3 _mouseReference;
    float _rotVelocity;

    void RotateObject(Vector2 pos)
    {
        float _sensitivity = .25f;

        if (!_isRotating)
        {
            _isRotating = true;
            _mouseReference = Input.mousePosition;
        }
        else
        {
            Vector3 _mouseOffset = (Input.mousePosition - _mouseReference);
            _rotVelocity = -(_mouseOffset.x) * _sensitivity;
            transform.Rotate(0, _rotVelocity, 0);

            _mouseReference = Input.mousePosition;
        }
    }

    void CheckLastVelocity()
    {
        if (!Mathf.Approximately(_rotVelocity, 0))
        {
            float deltaVelocity = Mathf.Min(
                Mathf.Sign(_rotVelocity) * Time.deltaTime * ((_rotVelocity > 8) ? 250 : 100),
                Mathf.Sign(_rotVelocity) * _rotVelocity
            );

            _rotVelocity -= deltaVelocity;
            transform.Rotate(0, _rotVelocity, 0);
        }
    }

    void ZoomObject(Touch t1, Touch t2)
    {
        Vector2 touchZeroPrevPos = t1.position - t1.deltaPosition;
        Vector2 touchOnePrevPos = t2.position - t2.deltaPosition;

        float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
        float touchDeltaMag = (t1.position - t2.position).magnitude;

        // float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;
        float deltaMagnitudeDiff = touchDeltaMag - prevTouchDeltaMag;


        float val = Mathf.Clamp((deltaMagnitudeDiff / (Screen.width / 4)), -1f, 1f);
        float speed = (((t1.deltaPosition.magnitude / t1.deltaTime) + (t2.deltaPosition.magnitude / t2.deltaTime)) / 2) / (Screen.width / 4);

        ZoomARSessionOrigin(new Vector3(val * speed, val * speed, val * speed));

        // reset rotate vel
        _rotVelocity = 0;
    }

    void ZoomARSessionOrigin(Vector3 scale)
    {
        transform.localScale += scale;

        //clamp scale
        transform.localScale = new Vector3(
            Mathf.Clamp(transform.localScale.x, _minSize, _maxSize),
            Mathf.Clamp(transform.localScale.y, _minSize, _maxSize),
            Mathf.Clamp(transform.localScale.z, _minSize, _maxSize)
        );
    }

    void Update()
    {
        if (Input.touchCount == 1)
            RotateObject(Input.GetTouch(0).position);
        else if (Input.touchCount == 2 && Input.GetTouch(0).phase == TouchPhase.Moved && Input.GetTouch(1).phase == TouchPhase.Moved)
            ZoomObject(Input.GetTouch(0), Input.GetTouch(1));
        else
        {
            _isRotating = false;
            CheckLastVelocity();
        }
    }
}
