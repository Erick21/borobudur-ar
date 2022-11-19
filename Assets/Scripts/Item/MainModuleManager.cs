using UnityEngine;

public class MainModuleManager : MonoBehaviour
{
    public static MainModuleManager init;

    public const string REQ_USER_PERMISSION = "RequestUserPermission";

    public static GameObject currentActiveModuleObject;

    [HideInInspector] public bool isRotating;

    void Awake()
    {
        init = this;
    }


    #region Rotate
    Vector3 _mouseReference;
    float _rotVelocity;

    void RotateObject(Vector2 pos)
    {
        float _sensitivity = .25f;

        if (Vector2.Distance(pos, new Vector2(Screen.width / 2, Screen.height / 2)) < Screen.height / 3)
        {
            if (!isRotating)
            {
                isRotating = true;
                _mouseReference = Input.mousePosition;
            }
            else
            {
                Vector3 _mouseOffset = (Input.mousePosition - _mouseReference);
                _rotVelocity = -(_mouseOffset.x) * _sensitivity;
                currentActiveModuleObject.transform.Rotate(0, _rotVelocity, 0);

                _mouseReference = Input.mousePosition;
            }
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
            currentActiveModuleObject.transform.Rotate(0, _rotVelocity, 0);
        }
    }
    #endregion

    #region  Zoom
    void ZoomObject(Touch t1, Touch t2)
    {
        Vector2 touchZeroPrevPos = t1.position - t1.deltaPosition;
        Vector2 touchOnePrevPos = t2.position - t2.deltaPosition;

        // Find the magnitude of the vector (the distance) between the touches in each frame
        float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
        float touchDeltaMag = (t1.position - t2.position).magnitude;

        // Find the difference in the distances between each frame
        float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

        float val = Mathf.Clamp((deltaMagnitudeDiff / (Screen.width / 4)), -.02f, .02f);
        float speed = (((t1.deltaPosition.magnitude / t1.deltaTime) + (t2.deltaPosition.magnitude / t2.deltaTime)) / 2) / (Screen.width / 4);

        CamFocusController.init.Zoom(new Vector3(val * speed, val * speed, val * speed));

        // reset rotate vel
        _rotVelocity = 0;
    }
    #endregion

    void Update()
    {
        if (Input.touchCount == 1)
            RotateObject(Input.GetTouch(0).position);
        else if (Input.touchCount == 2 && Input.GetTouch(0).phase == TouchPhase.Moved && Input.GetTouch(1).phase == TouchPhase.Moved)
            ZoomObject(Input.GetTouch(0), Input.GetTouch(1));
        else
        {
            isRotating = false;
            CheckLastVelocity();
        }
    }
}
