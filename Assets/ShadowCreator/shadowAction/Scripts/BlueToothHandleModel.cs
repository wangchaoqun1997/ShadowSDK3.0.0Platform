using ShadowKit.Action;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueToothHandleModel : MonoBehaviour {

    public MeshRenderer backKey;
    public MeshRenderer powerKey;
    public MeshRenderer tpKey;
    public MeshRenderer triggerKey;
    public MeshRenderer volumeDown;
    public MeshRenderer volumeUp;
    public Transform tpPosition;
    public Material releaseMaterial;
    public Material pressMaterial;

    Coroutine touchDircionCoroutine;
    int deviceId;
    bool isTouch;

    
    // Use this for initialization
    void Start() {
        deviceId = 0;
        isTouch = false;
        if (transform.parent && transform.parent.GetComponent<BlueToothHandle>()) {
            deviceId = (int)transform.parent.GetComponent<BlueToothHandle>().deviceId;
        }
        ActionInput.BluetoothHandleClickEvent += HandleKeysColor;
        ActionInput.TouchBeginEvent += TouchBegin;
        ActionInput.TouchEndEvent += TouchEnd;
    }


    // Update is called once per frame
    void LateUpdate() {
        if (isTouch) {
            if (!tpPosition.gameObject.activeSelf) {
                tpPosition.gameObject.SetActive(true);
            }
            tpPosition.localPosition = new Vector3((ActionInput.DeviceTouchPosition[deviceId].x-125)*0.00012f, tpPosition.localPosition.y, (ActionInput.DeviceTouchPosition[deviceId].y - 125) *0.00012f);
            if (touchDircionCoroutine == null) {
                Debug.Log("wangcq327 --- StartCoroutine device " + deviceId);
                touchDircionCoroutine = StartCoroutine("TouchEvent",deviceId);
            }
        } else {
            if (tpPosition.gameObject.activeSelf) {
                tpPosition.gameObject.SetActive(false);
            }
            if (touchDircionCoroutine != null) {
                StopCoroutine("TouchEvent");
                touchDircionCoroutine = null;
            }
        }
    }

    void TouchBegin(int _deviceId) {
        if (_deviceId != deviceId)
            return;
        isTouch = true;
    }
    void TouchEnd(int _deviceId) {
        if (_deviceId != deviceId)
            return;
        isTouch = false;
    }
    void HandleKeysColor(ActionKeyCode code, ActionKeyEvent type, int _deviceId) {
        if (_deviceId != deviceId)
            return;
        if (releaseMaterial == null || pressMaterial == null) {
            Debug.LogError("Please init Material");
            return;
        }

        Material currentMaterial = releaseMaterial;
        if (type == ActionKeyEvent.DOWN || type == ActionKeyEvent.LONG) {
            currentMaterial = pressMaterial;
        }

        if (code == ActionKeyCode.BACK && backKey != null) {
            backKey.material = currentMaterial;
        } else if (code == ActionKeyCode.POWER && powerKey != null) {
            powerKey.material = currentMaterial;
        } else if (code == ActionKeyCode.TIGGER && triggerKey != null) {
            triggerKey.material = currentMaterial;
        } else if (code == ActionKeyCode.TP && tpKey != null) {
            tpKey.material = currentMaterial;
        } else if (code == ActionKeyCode.VOLUMEDOWN && volumeDown != null) {
            //volumeDown.material = currentMaterial;
        } else if (code == ActionKeyCode.VOLUMEUP && volumeUp != null) {
            //volumeUp.material = currentMaterial;
        } else if (code == ActionKeyCode.OTHER) {

        }
    }

    IEnumerator TouchEvent(int deviceId) {
        Vector2 pos = ActionInput.DeviceTouchPosition[deviceId];
        Vector2 delatPos = Vector2.zero;

        for (float _time = 100f; _time > 0; _time -= Time.deltaTime) {
            Vector2 _posCurrent = ActionInput.DeviceTouchPosition[deviceId];
            delatPos.x += pos.x - _posCurrent.x;
            delatPos.y += pos.y - _posCurrent.y;
            pos.x = _posCurrent.x;
            pos.y = _posCurrent.y;
            if (0 != _posCurrent.x && 0 != _posCurrent.y) {
                if (delatPos.x <= -55.0f) {
                    Debug.Log("wangcq327 --- right");
                    ActionInput.onTouchRight(deviceId);
                    break;
                } else if (delatPos.x >= 55.0f) {
                    Debug.Log("wangcq327 --- left");
                    ActionInput.onTouchLeft(deviceId);
                    break;
                }
                if (delatPos.y <= -45.0f) {
                    Debug.Log("wangcq327 --- up");
                    ActionInput.onTouchUp(deviceId);
                    break;
                } else if (delatPos.y >= 55.0f) {
                    Debug.Log("wangcq327 --- down");
                    ActionInput.onTouchDown(deviceId);
                    break;
                }
            } else {
                break;
            }
            yield return null;
        }

    }
}
