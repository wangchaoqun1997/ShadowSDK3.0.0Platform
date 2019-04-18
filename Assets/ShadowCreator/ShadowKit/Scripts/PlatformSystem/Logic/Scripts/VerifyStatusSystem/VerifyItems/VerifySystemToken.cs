

using LitJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class VerifySystemToken:VerifyItemBase {

    /// <summary>
    /// 刷新SystemToken状态
    /// </summary>
    public override void OnUpdate() {
        if (SysInfo.IsTokenValid() == true) {
            verifyState = VerifyState.Success;
        } else{
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
    public override void Start() {
        //WebRequestSystem.Instant.GetSystemToken(GetSystemTokenSuccess, GetSystemTokenFailed);
        GetSystemTokenFailed(null);
    }
    private void GetSystemTokenSuccess(JsonData jsonData) {
        SysInfo.SetSysInfo(jsonData);
    }
    private void GetSystemTokenFailed(JsonData jsonData) {
        DebugMy.Log("GetSystemTokenFailed",this);
        SysInfo.ResetSysInfo();
        LoginSystem.SetStrategy(new LoginStrategyAccountAndPasswordFrowWebRequest());
        LoginSystem.Login();
    }

}
