using System;
using System.Collections.Generic;
using System.Text;
using LitJson;
using UnityEngine;

public class WebRequestRegister : WebRequestBase {
    public WebRequestRegister(WWWForm _form, Action<JsonData> success, Action<JsonData> failed) : base(WebRequestURL.Register, _form, success, failed) {
        webRequestType = WebRequestType.POST;
    }
}