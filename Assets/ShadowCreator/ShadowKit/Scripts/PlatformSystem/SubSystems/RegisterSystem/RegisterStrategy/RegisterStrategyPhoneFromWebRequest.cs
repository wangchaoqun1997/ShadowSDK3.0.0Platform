using LitJson;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class RegisterStrategyPhoneFromWebRequest : RegisterStrategyBase {

    public override void Register(params string[] s) {
        PlatformUISystem.Instant.uiPanelsManager.PushUIPanel(UIPanelsType.RegisterPhoneAndVerificationCodePanel);
    }

    public override void RegisterCallBack(Action<object> sucess = null, Action<object> failed = null) {
        //throw new NotImplementedException();
    }








}