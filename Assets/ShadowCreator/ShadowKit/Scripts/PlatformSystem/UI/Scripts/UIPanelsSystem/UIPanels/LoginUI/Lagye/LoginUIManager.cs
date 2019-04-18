using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class LoginUIManager {
    public static LoginBaseUI loginUI;

    public static void SetLoginUIType(LoginBaseUI _loginUI) {
        loginUI = _loginUI;
    }

    public static void SetLoginUIType(LoginUIType _loginUIType) {
        if (_loginUIType == LoginUIType.AccountAndPassword) {
            loginUI = new LoginAccountAndPasswordUI();
        } else if (_loginUIType == LoginUIType.PhoneAndVerificationCode) {
            loginUI = new LoginPhoneAndVerificationCodeUI();
        }
    }

}
