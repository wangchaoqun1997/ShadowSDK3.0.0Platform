
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
    public override void OnUpdateVerifyState() {
        if (UserSystem.Instant.AppInfo.IsTokenValid() == true) {
            verifyState = VerifyState.Success;
        } else {
            if (verifyState == VerifyState.Doning) {
                return;
            }
            verifyState = VerifyState.Failed;
        }
    }

    /// <summary>
    /// 执行state是Failed时的动作
    /// </summary>
    public override void DoSolve() {
        base.DoSolve();
        WebRequestSystem.Instant.GetAppToken(GetAppTokenSuccess, GetAppTokenFailed);
    }
    public static void GetAppTokenSuccess(JsonData responseJsonData) {
        UserSystem.Instant.AppInfo.SetAppInfo(responseJsonData);

        UserSystem.Instant.SysInfo.mUser.Uid = responseJsonData["data"]["uid"].ToString();

    }
    public static void GetAppTokenFailed(JsonData responseJsonData) {
        PlatformUISystem.Instant.uiPanelsManager.PushUIPanel(UIPanelsType.InfoType1Panel, "ERROR: Get APPToken Error");
        //Application.Quit();
    }

}
