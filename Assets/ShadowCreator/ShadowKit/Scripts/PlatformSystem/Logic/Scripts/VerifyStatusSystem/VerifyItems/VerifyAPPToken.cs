
using LitJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class VerifyAPPToken:VerifyItemBase {
    /// <summary>
    /// 刷新SystemToken状态
    /// </summary>
    public override void OnUpdate() {
        if (UserSystem.Instant.AppInfo.IsTokenValid() == true) {
            verifyState = VerifyState.Success;
        } else {
            if (verifyState == VerifyState.Doning) {
                DebugMy.Log(verifyState.ToString(), this);
                return;
            }
            verifyState = VerifyState.Failed;
        }
        DebugMy.Log(verifyState.ToString(), this);
    }

    /// <summary>
    /// 执行获取SystemToken过程
    /// </summary>
    public override void DoVerifyStart() {

        WebRequestSystem.Instant.GetAppToken(GetAppTokenSuccess, GetAppTokenFailed);
    }
    public static void GetAppTokenSuccess(JsonData responseJsonData) {
        UserSystem.Instant.AppInfo.SetAppInfo(responseJsonData);

        UserSystem.Instant.SysInfo.mUser.Uid = responseJsonData["data"]["uid"].ToString();

    }
    public static void GetAppTokenFailed(JsonData responseJsonData) {
        PlatformUISystem.Instant.uiPanelsManager.PushUIPanel(UIPanelsType.InfoType1Panel, "ERROR: Get APPToken Error");

        Debug.Log("sleep 5 finished");
        //Application.Quit();
    }

}
