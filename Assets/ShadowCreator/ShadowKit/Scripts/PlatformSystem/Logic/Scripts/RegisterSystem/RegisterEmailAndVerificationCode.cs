using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShadowKit;

namespace Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Register {
    public class RegisterEmailAndVerificationCode:RegisterBase {

        public RegisterEmailAndVerificationCode() {
            registerType = RegisterType.EmailAndVerificationCode;
        }

        public override void Register(string s1, string s2) {
            base.Register(s1, s2);

            ///邮箱格式判断
            if (!EmailTool.IsEmail(s1)) {
                //PlatformUISystem.Instant.SetPopupInfo("邮箱名格式不对");
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
