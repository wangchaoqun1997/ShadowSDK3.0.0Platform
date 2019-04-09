using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Login {
   public class LoginManager {

        private static LoginBase loginBase;
        
        public static void SetLoginType(LoginBase _loginBase) {
            loginBase = _loginBase;
        }

        //public static void SetLoginType(LoginType loginType) {
        //    if (loginType == LoginType.AccountAndPassword) {
        //        loginMode = new LoginAcountAndPassword();
        //    } else if (loginType == LoginType.PhoneAndVerificationCode) {
        //        loginMode = new LoginPhoneAndVerificationCode();
        //    }
        //}


        public static void Login(string s1="",string s2="") {
            if (loginBase == null) {
                Debug.LogError("you muse set loginType");
                return;
            }
            loginBase.Login(s1,s2);
        }

    }
}
