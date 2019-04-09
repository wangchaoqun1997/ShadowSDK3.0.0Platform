using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Logic.Scripts.Model;
using Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.UI.Scripts;
using LitJson;
using UnityEngine;

namespace Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Tools.Web {
    class WebRequestGetAppToken : WebRequestBase {

        public WebRequestGetAppToken(WWWForm form) :base(WebRequestURL.webRequestGetAppToken, form) {
            webRequestType = WebRequestType.POST;
            LOGTAG = "[WebRequestGetAppToken]:";
        }


        public override void Success(JsonData responseJsonData) {
            base.Success(responseJsonData);

            AppInfo.APPToken = responseJsonData["app_token"].ToString();
            UserInfo.Uid = responseJsonData["uid"].ToString();

        }
        public override void Failed(JsonData responseJsonData) {
            base.Failed(responseJsonData);
            PlatformUISystem.Instant.uiPanelsManager.PushUIPanel(UIPanelsType.InfoType1Panel, "ERROR: Get APPToken Error");
            
            Debug.Log(LOGTAG+"sleep 5 finished");
            //Application.Quit();
        }

    }
}
