using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Logic.Scripts.Login.AndroidListener;
using Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Login;
using Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Tools;
using ShadowKit;
using UnityEngine;

public class LoginAcountAndPassword:LoginBase {
    public LoginAcountAndPassword() {
        loginType = LoginType.AccountAndPassword;
        LOGTAG = "[LoginAcountAndPassword]:";
        loginAndroidListener = new LoginAccountAndPasswordListener();
    }

    public override void Login(string account, string password) {
        
        base.Login(account,password);

        if (loginAndroidListener != null) {
#if UNITY_ANDROID && !UNITY_EDITOR
		//if ( !UserInfo.isLogin()) {
			AndroidConnection.Instance.addListener<LoginAccountAndPasswordListener> ("setLoginSystemCallback", (LoginAccountAndPasswordListener)loginAndroidListener);
            AndroidConnection.Instance.Call ("unityLoginAndRegister");
       // }
#endif
        }

    }



    //    void OnApplicationFocus(bool hasFocus) {
    //#if UNITY_ANDROID && !UNITY_EDITOR
    //		if (hasFocus && !UserInfo.isLogin()) {
    //			AndroidConnection.Instance.Call ("unityInitCompleted");
    //		}
    //#endif
    //    }

}
