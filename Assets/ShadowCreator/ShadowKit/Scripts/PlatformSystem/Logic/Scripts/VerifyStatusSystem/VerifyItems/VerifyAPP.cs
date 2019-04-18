


using LitJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class VerifyAPP:VerifyItemBase {

    public override void OnUpdate() {
        
    }

    public override void PreEnter() {
        base.PreEnter();
        AppInfo.APPID = "100001";
        AppInfo.APPKEY = "123456";
    }

    public override void Start() {
        //WebRequestSystem.Instant.VerifyAPPID(VerifyAPPIDSuccess, VerifyAPPIDFailed);
        VerifyAPPIDSuccess(null);
    }

    public override void Exit() {
        
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
        AppInfo.ResetAppInfo();

        PlatformUISystem.Instant.uiPanelsManager.PushUIPanel(UIPanelsType.InfoType1Panel, "ERROR:APPID and APPKey Illegal");
        // Application.Quit();
    }


}
