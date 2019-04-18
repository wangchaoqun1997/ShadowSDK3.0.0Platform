
using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

class WebRequestLogin : WebRequestBase {



    public WebRequestLogin(WWWForm form, Action<JsonData> success, Action<JsonData> failed) : base(WebRequestURL.Login, form, success, failed) {
        webRequestType = WebRequestType.POST;
        LOGTAG = "[WebRequestLogin]:";
    }

    //public override void Failed(JsonData responseJsonData) {
    //}


    //public override void Success(JsonData responseJsonData) {
    //    SysInfo.systemToken = responseJsonData["token"].ToString();
    //    UserInfo.Uid = responseJsonData["uid"].ToString();


    //    WWWForm form = new WWWForm();
    //    WebRequestBase wq = new WebRequestGetAppToken(form);
    //    WebRequestSystem.Instant.AddWebRequest(wq);
    //}

}
