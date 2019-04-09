using Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Logic.Scripts.Login.AndroidListener;
using Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Login;
using ShadowKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Logic.Scripts.Login {
    class LoginDefault : LoginBase {

        public LoginDefault() {
            loginType = LoginType.Default;
#if UNITY_ANDROID && !UNITY_EDITOR
            loginAndroidListener = new LoginDefaultListener();
#endif
            LOGTAG = "[LoginDefault]:";
        }

        public override void Login(string s1, string s2) {
            base.Login(s1, s2);

#if UNITY_ANDROID && !UNITY_EDITOR
		//if ( !UserInfo.isLogin()) {
		    AndroidConnection.Instance.addListener<LoginDefaultListener> ("setLoginSystemCallback",(LoginDefaultListener)loginAndroidListener);
			//AndroidConnection.Instance.Call ("unityInitCompleted",account,password);
            AndroidConnection.Instance.Call ("unityLoginAndRegister");
       // }
#endif
        }


        public override void Sucess(object parms=null) {
            base.Sucess(parms);
            Debug.Log("LoginListener.onLoginSuccess=====>" + parms as string);
            UserInfo.Account = parms as string;
        }

        public override void Failed(object parms = null) {
            base.Failed(parms);
            Debug.Log("LoginListener.onLoginFailed=====>" + parms as string);
            //UserInfo.Account = UserInfo.Serialno;
        }
    }
}
