using LitJson;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class LoginStrategyAccountAndPasswordFrowWebRequest : LoginStrategyBase {

    public override void Login(params string[] s) {
        PlatformUISystem.Instant.uiPanelsManager.PushUIPanel(UIPanelsType.LoginAcountAndPasswordPanelWithVerificationcode);

    }

    public override void RegisterCallBack(Action<object> sucess = null, Action<object> failed = null) {
        //throw new NotImplementedException();
    }








}