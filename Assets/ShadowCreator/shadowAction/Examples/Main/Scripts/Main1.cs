using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main1 : MonoBehaviour {
    [Header("You Must init")]
    public BaseList baseList;
    
    
    void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }

    // Use this for initialization
    void Start() {
        baseList.configs = new List<object>();
        baseList.configs.Add(new AScene("Assets/ShadowCreator/shadowAction/Examples/HelloWorld/HelloWorld.unity", "HelloWorld", "第一个例子"));
        baseList.configs.Add(new AScene("Assets/ShadowCreator/shadowAction/Examples/AnyClick/AnyClick.unity", "AnyClick", "任意键点击"));
        baseList.configs.Add(new AScene("Assets/ShadowCreator/shadowAction/Examples/Click/3DClick.unity", "3DClick", "点击3D物体"));
        baseList.configs.Add(new AScene("Assets/ShadowCreator/shadowAction/Examples/Click/CanvaClick.unity", "CanvaClick", "点击2D UI"));
        baseList.configs.Add(new AScene("Assets/ShadowCreator/shadowAction/Examples/keyboard/keyboard.unity", "keyboard", "3D键盘的使用"));
        baseList.configs.Add(new AScene("Assets/ShadowCreator/shadowAction/Examples/BluetoothHandle3dof/BlueTooth.unity", "BlueTooth", "蓝牙手柄姿态获取"));
        baseList.configs.Add(new AScene("Assets/ShadowCreator/shadowAction/Examples/BluetoothHandleClick/BluetoothHandleClick.unity", "BluetoothHandleClick", "蓝牙手柄滑动操作"));
        baseList.configs.Add(new AScene("Assets/ShadowCreator/shadowAction/Examples/BluetoothHandleDrag/BluetoothHandleDrag.unity", "BluetoothHandleDrag", "蓝牙手柄拖拽操作"));
        baseList.configs.Add(new AScene("Assets/ShadowCreator/shadowAction/Examples/BluetoothHandleCombineKey/BluetoothHandleCombineKey.unity", "BluetoothHandleCombineKey", "蓝牙手柄组合键操作"));
        baseList.configs.Add(new AScene("Assets/ShadowCreator/shadowAction/Examples/Gaze/Gaze_Head.unity", "Gaze_Head", "头部自动凝视"));
        baseList.configs.Add(new AScene("Assets/ShadowCreator/shadowAction/Examples/Gaze/Gaze_Bluetooth.unity", "Gaze_Bluetooth", "手柄凝视"));

        baseList.Refresh();
    }

    // Update is called once per frame
    void Update() {

    }
    
}
