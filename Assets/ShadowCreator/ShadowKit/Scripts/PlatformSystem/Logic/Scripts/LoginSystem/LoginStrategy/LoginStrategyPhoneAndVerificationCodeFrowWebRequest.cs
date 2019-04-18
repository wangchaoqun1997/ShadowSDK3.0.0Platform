using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class LoginStrategyPhoneAndVerificationCodeFrowWebRequest : LoginStrategyBase {

    public override void Login(params string[] s) {
        
    }

    public override void RegisterCallBack(Action<object> sucess = null, Action<object> failed = null) {
        throw new NotImplementedException();
    }

}