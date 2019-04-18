using System;
using LitJson;
using UnityEngine;

class WebRequestGetSystemToken : WebRequestBase {

    public WebRequestGetSystemToken(WWWForm form, Action<JsonData> success, Action<JsonData> failed) : base(WebRequestURL.GetSystemToken, form, success, failed) {
        webRequestType = WebRequestType.POST;
        LOGTAG = "[WebRequestGetSystemToken]:";
    }

}
