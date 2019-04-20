


using LitJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class VerifyAPP:VerifyItemBase {
    

    public override void DoSolve() {
        base.DoSolve();
        //WebRequestSystem.Instant.VerifyAPPID(VerifyAPPIDSuccess, VerifyAPPIDFailed);

        UserSystem.Instant.AppInfo.APPID = "100001";
        UserSystem.Instant.AppInfo.APPKEY = "123456";


        VerifyAPPIDSuccess(null);
    }
    



    private void VerifyAPPIDSuccess(JsonData responseJsonData) {
        DebugMy.Log("VerifyAPPIDSuccess",this);
        verifyState = VerifyState.Success;
        //APP合法
        //AppInfo.SetAppInfo(responseJsonData);
        
    }


    private void VerifyAPPIDFailed(JsonData responseJsonData) {
        Debug.Log("VerifyAPPIDFailed");
        verifyState = VerifyState.Failed;
        //App非法
        UserSystem.Instant.AppInfo.ResetAppInfo();

        PlatformUISystem.Instant.uiPanelsManager.PushUIPanel(UIPanelsType.InfoType1Panel, "ERROR:APPID and APPKey Illegal");
        // Application.Quit();
    }

    public override void OnUpdateVerifyState() {

    }
}
