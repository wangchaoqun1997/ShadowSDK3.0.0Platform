using System;
using LitJson;
using UnityEngine;

class WebRequestVerifyAPPID : WebRequestBase {

    public WebRequestVerifyAPPID(WWWForm form, Action<JsonData> success, Action<JsonData> failed) : base(WebRequestURL.VerifyAPPID, form, success, failed) {
        webRequestType = WebRequestType.POST;
        LOGTAG = "[WebRequestVerifyAPPID]:";
    }

}
