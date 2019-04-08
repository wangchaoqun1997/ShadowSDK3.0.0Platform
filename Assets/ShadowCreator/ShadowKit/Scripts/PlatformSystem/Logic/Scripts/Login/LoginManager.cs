using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Login {
    class LoginManager {

        public static LoginBase loginMode;
        
        public static void SetLoginType(LoginBase _loginMode) {
            loginMode = _loginMode;
        }

        public static void SetLoginType(LoginType loginType) {
            if (loginType == LoginType.AccountAndPassword) {
                loginMode = new LoginAcountAndPassword();
            } else if (loginType == LoginType.PhoneAndVerificationCode) {
                loginMode = new LoginPhoneAndVerificationCode();
            }
        }


        public static void Login(string s1,string s2) {
            if (loginMode == null) {
                Debug.LogError("you muse set loginType");
                return;
            }
            loginMode.Login(s1,s2);
        }
        
    }
}
