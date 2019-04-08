using ShadowKit;
using ShadowKit.Action;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BluetoothHandleDrag : MonoBehaviour{

    public Transform dragParent;
    public TextMesh info;
    //当setparent为DonotDestroy的gameobject后，在Setparent null ，此物体会处于DonotDestroy状态
    public Transform noDragParent;
    public float oneStep = 0.1f;
    Transform dragObj;

    void Start() {
        ActionInput.TouchLeftEvent += TouchLeft;
        ActionInput.TouchRightEvent += TouchRight;
        ActionInput.TouchDownEvent += TouchDown;
        ActionInput.TouchUpEvent += TouchUp;
        ActionInput.BluetoothHandleClickEvent += TriggerClick;
        ActionInput.BluetoothHandleConnectEvent += HandlerConnect;
        ActionInput.BluetoothHandleUnConnectEvent += HandlerDisConnect;

        if (ActionInput.IsBluetoothHandleConnected(0)) {
            SetInfo("请点击物体");
        } else {
            SetInfo("请连接蓝牙手柄");
        }
        if (noDragParent == null && transform.parent != null) {
            noDragParent = transform.parent;
        }

        dragObj = null;
        
    }

    //ActionSystem Destory需要一段时间
    void OnRenderObject() {
        if (dragParent == null) {
            dragParent = GameObject.Find("ActionSystem").transform.Find("BlueToothHandle");
        }
    }

    void Update() {

    }

    public bool DragObj() {
        if (SCInput.Instance.target == gameObject && dragObj == null) {
            dragObj = transform;
            dragObj.SetParent(dragParent);
        }
        return dragObj != null;

    }
    public bool ReleaseDragObj() {
        if (dragObj) {
            dragObj.parent = noDragParent;
            dragObj = null;
        }
        return dragObj == null;
    }
    public void SetInfo(string _info) {
        if (info) {
            info.text = _info;
        }
    }


    void OnDestroy() {
        ActionInput.TouchLeftEvent -= TouchLeft;
        ActionInput.TouchRightEvent -= TouchRight;
        ActionInput.TouchDownEvent -= TouchDown;
        ActionInput.TouchUpEvent -= TouchUp;
        ActionInput.BluetoothHandleClickEvent -= TriggerClick;
        ActionInput.BluetoothHandleConnectEvent -= HandlerConnect;
        ActionInput.BluetoothHandleUnConnectEvent -= HandlerDisConnect;
    }
    void HandlerConnect(int deviceId) {
        if (deviceId != 0)
            return;
        SetInfo("请点击物体");
    }
    void HandlerDisConnect(int deviceId) {
        if (deviceId != 0)
            return;
        SetInfo("请连接蓝牙手柄");
    }
    void TriggerClick(ActionKeyCode code, ActionKeyEvent type, int deviceId) {
        if (code == ActionKeyCode.TIGGER && type == ActionKeyEvent.DOWN && deviceId == 0) {
            if (dragObj != null) {
                if (ReleaseDragObj() == true) {
                    SetInfo("请点击物体");
                }
            } else {
                if (DragObj() == true) {
                    SetInfo("请上下或左右滑动TP");
                }
            }
        }
    }
    void TouchLeft(int deviceId) {
        if (deviceId != 0)
            return;
        if (dragObj) {
            dragObj.transform.localPosition = new Vector3(dragObj.transform.localPosition.x, dragObj.transform.localPosition.y, dragObj.transform.localPosition.z - oneStep);
        }
    }
    void TouchRight(int deviceId) {
        if (deviceId != 0)
            return;
        if (dragObj) {
            dragObj.transform.localPosition = new Vector3(dragObj.transform.localPosition.x, dragObj.transform.localPosition.y, dragObj.transform.localPosition.z + oneStep);
        }
    }
    void TouchDown(int deviceId) {
        if (deviceId != 0)
            return;
        if (dragObj) {
            dragObj.transform.localPosition = new Vector3(dragObj.transform.localPosition.x, dragObj.transform.localPosition.y, dragObj.transform.localPosition.z - oneStep);
        }
    }
    void TouchUp(int deviceId) {
        if (deviceId != 0)
            return;
        if (dragObj) {
            dragObj.transform.localPosition = new Vector3(dragObj.transform.localPosition.x, dragObj.transform.localPosition.y, dragObj.transform.localPosition.z + oneStep);
        }
    }
}
