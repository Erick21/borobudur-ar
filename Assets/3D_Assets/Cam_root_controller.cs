using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cam_root_controller : MonoBehaviour {
    // DEBUG ONLY
    public Text TxOut_U;
    public Text TxOut_B;

    //DYNAMIC VARIABLES
    public float panSpeed;
    public float zoomSpeed;
    public float rotSpeed;

    //CAM SET
    public Transform rootTransform;
    public Transform tiltTransform;
    public Transform camTransform;

    private Vector3 downInput;
    private Vector3 currInput;
    private Vector3 downRay;
    private Vector3 currRay;
    private Vector3 downCamPos;
    private Vector3 downBallRot;
    private float reuseX;
    private float reuseY;
    private int intX;
    private int intY;
    private bool mDown;
    private int MouseButtonState;
    private int MouseButtonLastState;


    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        HandleMouseInput();
    }

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void ZoomCam(float zVal){
        if ((zVal < -1.5) && (zVal > -100f)) {
            camTransform.localPosition = new Vector3(camTransform.localPosition.x, camTransform.localPosition.y, zVal);
        }
    }

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void HandleMouseInput(){
        //MOUSE UP AND OR DOWN //////////////////////////////////////////////////////////////
        if (Input.GetMouseButtonDown(0)) {MouseButtonState = 1;}
        if (Input.GetMouseButtonDown(1)) {MouseButtonState = 2;}
        if (Input.GetMouseButtonDown(2)) {MouseButtonState = 3;}
        if (Input.GetMouseButtonUp(0)) {MouseButtonState = 0;}
        if (Input.GetMouseButtonUp(1)) {MouseButtonState = 0;}
        if (Input.GetMouseButtonUp(2)) {MouseButtonState = 0;}
        
        //ZOOM //////////////////////////////////////////////////////////////////////////////
        if (Input.mouseScrollDelta.y != 0) { 
            ZoomCam(camTransform.localPosition.z + (Input.mouseScrollDelta.y * zoomSpeed));
        }
        TxOut_B.text = "Mouse state : " + MouseButtonState.ToString();

        if (MouseButtonState == 1) {
           //
        }

        if (MouseButtonState == 3) {
            if (MouseButtonLastState == 0) {
                downInput = Input.mousePosition;
                downBallRot = tiltTransform.eulerAngles;
                downCamPos = camTransform.localPosition;
                Plane plane = new Plane(Vector3.up, Vector3.zero);
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (plane.Raycast(ray, out reuseX)) {
                    downRay = ray.GetPoint(reuseX);
                }
            }

            //MOUSE DOWN + MOVE /////////////////////////////////////////////////////////////
            if (Input.GetKey(KeyCode.LeftAlt)) { //ROTASI/ORBIT KAMERA
                currInput = Input.mousePosition;
                if (Input.GetKey(KeyCode.LeftControl)) {
                    //FINE ZOOM
                    reuseY = downInput.y - currInput.y;
                    ZoomCam(downCamPos.z - (reuseY * 0.05f * (zoomSpeed / 5)));
                } else {
                    currInput = currInput - downInput;
                    reuseX = downBallRot.x - (currInput.y * rotSpeed);
                    reuseY = downBallRot.y + (currInput.x * rotSpeed);
                    if (reuseX < 3f) {reuseX = 3f;}
                    if (reuseX > 90f) {reuseX = 90f;}
                    tiltTransform.rotation = Quaternion.Euler(reuseX, reuseY, 0);
                }
            } else {
                Plane plane = new Plane(Vector3.up, Vector3.zero);
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (plane.Raycast(ray, out reuseX)) {
                    currRay = ray.GetPoint(reuseX);
                    rootTransform.position = rootTransform.position + downRay - currRay;
                    rootTransform.position = new Vector3(0f, rootTransform.position.y, 0f);
                }
            }
        } else {
            Plane plane = new Plane(Vector3.up, Vector3.zero);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (plane.Raycast(ray, out reuseX)) {
                currRay = ray.GetPoint(reuseX);
            }
            intX = (int)currRay.x;
            intY = (int)currRay.z;
            TxOut_U.text = "Grid pos : " + intX.ToString() + ", " + intY.ToString();
            intX = (int)Input.mousePosition.x;
            intY = (int)Input.mousePosition.y;
            TxOut_U.text = TxOut_U.text + "   |   Mouse pos : " + intX.ToString() + ", " + intY.ToString();
        }
        MouseButtonLastState = MouseButtonState;
    }
}
