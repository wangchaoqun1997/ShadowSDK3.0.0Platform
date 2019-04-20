using System;
using LitJson;
using UnityEngine;

class WebRequestGetAppToken : WebRequestBase {

    public WebRequestGetAppToken(WWWForm form, Action<JsonData> success, Action<JsonData> failed) : base(WebRequestURL.GetAppToken, form, success, failed) {
        webRequestType = WebRequestType.POST;
        LOGTAG = "[WebRequestGetAppToken]:";
    }

}
