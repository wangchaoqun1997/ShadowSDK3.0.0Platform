using System;
using System.Collections.Generic;
using System.Text;
using LitJson;
using UnityEngine;

public class WebRequestGetRegisterPhoneVerificationcode : WebRequestBase {
    public WebRequestGetRegisterPhoneVerificationcode(WWWForm _form, Action<JsonData> success, Action<JsonData> failed) : base(WebRequestURL.GetRegisterPhoneVerificationCode, _form, success, failed) {
        webRequestType = WebRequestType.POST;
    }
}