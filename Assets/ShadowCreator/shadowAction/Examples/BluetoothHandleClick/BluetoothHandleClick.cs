using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ShadowKit.Action;

public class BluetoothHandleClick : MonoBehaviour {

	public MeshRenderer left;
	public MeshRenderer right;
	public MeshRenderer up;
	public MeshRenderer down;
	// Use this for initialization
	void Start () {
		ActionInput.TouchLeftEvent += TouchLeft;
        ActionInput.TouchRightEvent += TouchRight;
        ActionInput.TouchDownEvent += TouchDown;
        ActionInput.TouchUpEvent += TouchUp;
        ActionInput.TouchEndEvent += TouchEnd;
    }

    void OnDestroy() {
        ActionInput.TouchLeftEvent -= TouchLeft;
        ActionInput.TouchRightEvent -= TouchRight;
        ActionInput.TouchDownEvent -= TouchDown;
        ActionInput.TouchUpEvent -= TouchUp;
        ActionInput.TouchEndEvent -= TouchEnd;
    }
    void TouchEnd(int _deviceId) {
        if (_deviceId == 0) {
            left.materials[0].color = Color.white;
            right.materials[0].color = Color.white;
            down.materials[0].color = Color.white;
            up.materials[0].color = Color.white;
        }
    }
    void TouchLeft(int deviceId) {
        if (deviceId != 0)
            return;
        left.materials[0].color = Color.blue;
    }
    void TouchRight(int deviceId) {
        if (deviceId != 0)
            return;
        right.materials[0].color = Color.blue;
    }
    void TouchDown(int deviceId) {
        if (deviceId != 0)
            return;
        down.materials[0].color = Color.blue;
    }
    void TouchUp(int deviceId) {
        if (deviceId != 0)
            return;
        up.materials[0].color = Color.blue;
    }
}
