using Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Login {
    class LoginPhoneAndVerificationCode : LoginBase {

        public LoginPhoneAndVerificationCode() {
            loginType = LoginType.PhoneAndVerificationCode;
        }

        public override void Login(string phone, string verificationCode) {
            base.Login(phone, verificationCode);

            if (!PhoneTool.IsPhone(param1)) {
                return;
            }

#if UNITY_ANDROID && !UNITY_EDITOR
		if ( !UserInfo.isLogin()) {
			//AndroidConnection.Instance.addListener<LoginAndroidListener> ("setLoginSystemCallback",new LoginAndroidListener());
			//AndroidConnection.Instance.Call ("unityInitCompleted",account,password);
		}
#else
            UserInfo.Account = "1";
#endif

        }
    }
}
