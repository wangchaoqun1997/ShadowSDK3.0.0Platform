using LitJson;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class WebRequestGetSessionID : WebRequestBase {
    public WebRequestGetSessionID(WWWForm form, Action<JsonData> success, Action<JsonData> failed) : base(WebRequestURL.GetSessionId, form, success, failed) {
        webRequestType = WebRequestType.POST;
        LOGTAG = "[WebRequestGetAppToken]:";
    }
}