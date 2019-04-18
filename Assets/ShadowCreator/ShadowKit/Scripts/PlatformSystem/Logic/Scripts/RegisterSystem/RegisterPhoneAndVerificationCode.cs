using Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShadowKit;

namespace Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Register {
    public class RegisterPhoneAndVerificationCode : RegisterBase {

        public RegisterPhoneAndVerificationCode() {
            registerType = RegisterType.PhoneAndVerificationCode;
        }

        public override void Register(string s1, string s2) {
            base.Register(s1,s2);

            ///手机号判断
            if (!PhoneTool.IsPhone(parameter1)) {
                //PlatformUISystem.Instant.SetPopupInfo("手机号格式不对");
                return;
            }

#if UNITY_ANDROID && !UNITY_EDITOR
		if ( !UserInfo.isLogin()) {
			AndroidConnection.Instance.addListener<RegisterAndroidListener> ("setLoginSystemCallback",new RegisterAndroidListener());
			//AndroidConnection.Instance.Call ("unityInitCompleted",account,password);
            AndroidConnection.Instance.Call ("unityLoginAndRegister");
		}
#else
            UserInfo.Account = "1";
#endif
        }
    }
}
