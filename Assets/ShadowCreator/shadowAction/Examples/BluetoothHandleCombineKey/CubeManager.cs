using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ShadowKit.Action;
using UnityEngine.EventSystems;
using System;

public class CubeManager : MonoBehaviour{

    public TextMesh handlerInfo;
    public MeshRenderer[] cubesMeshRenderer;
    // Use this for initialization
    void Start() {
        handlerInfo.text = "手柄按键信息";
        ActionInput.BluetoothHandleCombineClickEvent += BluetoothHandleCombineClick;
        Init();
    }
    void OnDestroy() {
        ActionInput.BluetoothHandleCombineClickEvent -= BluetoothHandleCombineClick;
    }
    void Init() {
        foreach (MeshRenderer obj in cubesMeshRenderer) {
            obj.material.color = Color.white;
        }
        handlerInfo.text = "手柄按键信息" + "\n";
    }

    void BluetoothHandleCombineClick() {
        Init();
        foreach (KeyValuePair<ActionKeyCode, ActionKeyEvent> kv in ActionInput.ActionKeys) {
            // Debug.Log("wangcq327 ---kkk Unity onKeyEventChanged" + kv.Value + ";" + kv.Key);
            if (kv.Key == ActionKeyCode.VOLUMEDOWN || kv.Key == ActionKeyCode.VOLUMEUP || kv.Key == ActionKeyCode.OTHER) {
                continue;
            } 
            handlerInfo.text += "[Status] " + kv.Value +  "     [Key] " +kv.Key +  "\n";
        }

        //一个键监控
        if (ActionInput.ActionKeys[ActionKeyCode.TIGGER] == ActionKeyEvent.DOWN) {
            //do something
            cubesMeshRenderer[0].material.color = Color.blue;
        } else if (ActionInput.ActionKeys[ActionKeyCode.TIGGER] == ActionKeyEvent.UP) {
            //do something
            cubesMeshRenderer[0].material.color = Color.white;
        }

        //二个键监控
        if (ActionInput.ActionKeys[ActionKeyCode.TIGGER] == ActionKeyEvent.DOWN && ActionInput.ActionKeys[ActionKeyCode.TP] == ActionKeyEvent.DOWN) {
            //do something
            cubesMeshRenderer[1].material.color = Color.blue;
        }
        if (ActionInput.ActionKeys[ActionKeyCode.TIGGER] == ActionKeyEvent.DOWN && ActionInput.ActionKeys[ActionKeyCode.POWER] == ActionKeyEvent.DOWN) {
            //do something
            cubesMeshRenderer[2].material.color = Color.blue;
        }

        //三个键监控
        if (ActionInput.ActionKeys[ActionKeyCode.TIGGER] == ActionKeyEvent.DOWN && ActionInput.ActionKeys[ActionKeyCode.POWER] == ActionKeyEvent.DOWN && ActionInput.ActionKeys[ActionKeyCode.TP] == ActionKeyEvent.DOWN){
            //do something
            cubesMeshRenderer[3].material.color = Color.blue;
        }

        //依次类推，四个，五个，六个键监控
    }

}
