using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFocusController : MonoBehaviour
{
    [SerializeField] Transform _mainCamera;
    Transform _objectToView;

    public Transform objectToView
    {
        set { _objectToView = value; }
    }

    public static CamFocusController init;

    void Awake()
    {
        init = this;
    }

    void Update()
    {
        if (_objectToView != null)
            PositionCamera();
    }

    void PositionCamera()
    {
        Bounds objectBounds = _objectToView.GetComponent<Renderer>().bounds;
        Vector3 objectFrontCenter = objectBounds.center - _objectToView.forward * objectBounds.extents.z;

        Vector3 triangleFarSideUpAxis = Quaternion.AngleAxis(90, _objectToView.right) * _mainCamera.forward;

        const float MARGIN_MULTIPLIER = 10f;
        Vector3 triangleUpPoint = objectFrontCenter + triangleFarSideUpAxis * objectBounds.extents.y * MARGIN_MULTIPLIER;

        float desiredDistance = Vector3.Distance(triangleUpPoint, objectFrontCenter) / Mathf.Tan(Mathf.Deg2Rad * _mainCamera.GetComponent<Camera>().fieldOfView / 2);
        float curDis = Vector3.Distance(_mainCamera.position, -_mainCamera.forward * desiredDistance + objectFrontCenter);

        _mainCamera.position = Vector3.Lerp(_mainCamera.position, -_mainCamera.forward * desiredDistance + objectFrontCenter, Time.deltaTime * (.75f + (curDis / 10f)));
    }

    public void Zoom(Vector3 scale)
    {
        if (_objectToView != null)
        {
            _objectToView.localScale += scale;

            //clamp scale
            _objectToView.localScale = new Vector3(
                Mathf.Clamp(_objectToView.localScale.x, .05f, .5f),
                Mathf.Clamp(_objectToView.localScale.y, .05f, .5f),
                Mathf.Clamp(_objectToView.localScale.z, .05f, .5f)
            );
        }
    }
}
