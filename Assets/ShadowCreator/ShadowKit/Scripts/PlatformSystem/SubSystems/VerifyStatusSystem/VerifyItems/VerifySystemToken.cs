

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
    public override void OnUpdateVerifyState() {
        if (UserSystem.Instant.SysInfo.IsUserTokenValid == true) {
            verifyState = VerifyState.Success;
        } else{
            if (verifyState == VerifyState.Doning) {
                UserSystem.Instant.SysInfo.mUser.PrintInfo();
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
        LoginSystem.SetStrategy(new LoginStrategyAccountAndPasswordFrowWebRequest());
        LoginSystem.Login();
    }


}
