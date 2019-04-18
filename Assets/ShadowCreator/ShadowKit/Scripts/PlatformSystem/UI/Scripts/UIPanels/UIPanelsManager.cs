using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class UIPanelsManager {
    /// <summary>
    /// LOG Tag
    /// </summary>
    public const string LOGTAG = "[UIPanelsManager]:";

    /// <summary>
    /// 从UIPanelsJson解析获得的
    /// </summary>
    private Dictionary<UIPanelsType, string> uiPanelsDic = new Dictionary<UIPanelsType, string>();

    /// <summary>
    /// UIPanels的Canvas
    /// </summary>
    private GameObject uiPanelsCanvas;
    private string uiPanelsCanvasPath;

    /// <summary>
    /// 已经push过的UIPanels
    /// </summary>
    private Dictionary<UIPanelsType, BaseUIPanel> uiPanelsInstantDic = new Dictionary<UIPanelsType, BaseUIPanel>();

    /// <summary>
    /// 显示栈中的UIPanels
    /// </summary>
    private Stack<BaseUIPanel> uiPanelsStack = new Stack<BaseUIPanel>();

    //private static UIPanelsManager instant;
    //public static UIPanelsManager Instant {
    //    get {
    //        if (instant == null) {

    //            instant = new UIPanelsManager();
    //        }
    //        return instant;
    //    }
    //}

    public UIPanelsManager(bool isDonotDestoryLoad) {

        UIPanelsParseFromJson.GetUIPanels(uiPanelsDic, out uiPanelsCanvasPath);
        if (uiPanelsCanvasPath != String.Empty) {
            uiPanelsCanvas = GameObject.Instantiate(Resources.Load(uiPanelsCanvasPath)) as GameObject;
            if (isDonotDestoryLoad) {
                MonoBehaviour.DontDestroyOnLoad(uiPanelsCanvas);
            }
        }

    }

    //public void Init() {
    //    Debug.Log(LOGTAG + "Init start");
    //    UIPanelsParseFromJson.GetUIPanels(uiPanelsDic);
    //    Debug.Log(LOGTAG+"Init finish");
    //}

    public void PushUIPanel(UIPanelsType uiPanelsType, object parameter = null) {
        if (uiPanelsStack.Count != 0) {
            Debug.Log(LOGTAG + "PushUIPanel uiPanelsStack.Count != 0");
            BaseUIPanel uiPanelStackTop = uiPanelsStack.Peek();
            uiPanelStackTop.OnPause();
        }

        BaseUIPanel uiPanel = GetPanel(uiPanelsType);
        if (uiPanel != null) {
            Debug.Log(LOGTAG + "PushUIPanel GetPanel uiPanelsType");
            uiPanelsStack.Push(uiPanel);
            uiPanel.OnEnter(parameter);
        }

    }

    public void PopUIPanel() {

        if (uiPanelsStack.Count != 0) {
            Debug.Log(LOGTAG + "PopUIPanel uiPanelsStack.Pop");
            BaseUIPanel uiPanelStackTop = uiPanelsStack.Pop();
            uiPanelStackTop.OnExit();
        }

        if (uiPanelsStack.Count != 0) {
            Debug.Log(LOGTAG + "PopUIPanel uiPanelsStack.Peek");
            BaseUIPanel uiPanelStackTop = uiPanelsStack.Peek();
            uiPanelStackTop.OnResume();
        }

    }

    public void PopAllUIPanel() {
        while (uiPanelsStack.Count != 0) {
            PopUIPanel();
        }
    }

    private BaseUIPanel GetPanel(UIPanelsType uiPanelsType) {
        BaseUIPanel uiPanelInstant;

        uiPanelsInstantDic.TryGetValue(uiPanelsType, out uiPanelInstant);
        Debug.Log(LOGTAG + "GetPanel uiPlanesInstantDic.TryGetValue:" + uiPanelInstant);

        if (uiPanelInstant == null) {
            string uiPanelPath;
            uiPanelsDic.TryGetValue(uiPanelsType, out uiPanelPath);
            GameObject panel = GameObject.Instantiate(Resources.Load(uiPanelPath)) as GameObject;
            panel.transform.SetParent(uiPanelsCanvas.transform, false);

            uiPanelInstant = panel.GetComponent<BaseUIPanel>();
            uiPanelsInstantDic.Add(uiPanelsType, uiPanelInstant);
            Debug.Log(LOGTAG + "GetPanel uiPlanesDic.TryGetValue");
        }
        return uiPanelInstant;
    }

}
