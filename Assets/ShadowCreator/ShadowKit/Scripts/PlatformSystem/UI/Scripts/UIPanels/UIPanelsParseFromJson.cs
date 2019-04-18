using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

using System;

public class UIPanelsParseFromJson {

    public const string UIPanelJson = "JsonText/UIPanel";
    private static UIPanels uIPanels;

    class UIPanels {
        public UIPanelInfo UIPanelCanvas;
        public List<UIPanelInfo> UIPanelList;
    }
    class UIPanelInfo {
        public string UIPanelName;
        public string UIPanelPath;
    }

    /// <summary>
    /// 将Json字符串转换成UIPanels对象
    /// </summary>
    /// <returns></returns>
    public static bool JsonToObject() {
        TextAsset ta = Resources.Load<TextAsset>(UIPanelJson);
        if (ta == null) {
            Debug.LogError("Path error");
            return false;
        }

        uIPanels = JsonMapper.ToObject<UIPanels>(ta.text);
        Debug.Log(uIPanels.UIPanelCanvas.UIPanelName + "::" + uIPanels.UIPanelCanvas.UIPanelPath);

        foreach (UIPanelInfo uIPanelInfo in uIPanels.UIPanelList) {
            Debug.Log(uIPanelInfo.UIPanelName + "::" + uIPanelInfo.UIPanelPath);
        }
        return true;

    }

    /// <summary>
    /// 将UIPanels对象list检索，给UIPanelsManager中的baseUIPanels赋值
    /// </summary>
    /// <param name="baseUIPlanes"></param>
    public static void GetUIPanels(Dictionary<UIPanelsType, string> baseUIPlanes,out string uiPanelCanvasPath) {
        if (JsonToObject()) {

            foreach (UIPanelInfo uIPanelInfo in uIPanels.UIPanelList) {
                try {
                    UIPanelsType type = (UIPanelsType)System.Enum.Parse(typeof(UIPanelsType), uIPanelInfo.UIPanelName);
                    baseUIPlanes.Add(type, uIPanelInfo.UIPanelPath);
                } catch (Exception e) {
                    Debug.Log(e);
                }
            }

            uiPanelCanvasPath = uIPanels.UIPanelCanvas.UIPanelPath;
        } else {
            uiPanelCanvasPath = String.Empty;
        }


        
    }

}
