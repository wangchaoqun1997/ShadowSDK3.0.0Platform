using Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Logic.Scripts.Model;
using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Tools.Web {
    class WebRequestLogin:WebRequestBase {



        public WebRequestLogin(WWWForm form) : base(WebRequestURL.webRequestLogin, form) {
            webRequestType = WebRequestType.POST;
            LOGTAG = "[WebRequestLogin]:";
        }

        public override void Failed(JsonData responseJsonData) {
            base.Failed(responseJsonData);
        }


        public override void Success(JsonData responseJsonData) {
            base.Success(responseJsonData);
            SysInfo.systemToken = responseJsonData["token"].ToString();
            UserInfo.Uid = responseJsonData["uid"].ToString();


            WWWForm form = new WWWForm();
            WebRequestBase wq = new WebRequestGetAppToken(form);
            WebRequestManager.Instant.AddWebRequest(wq);
        }

    }
}
