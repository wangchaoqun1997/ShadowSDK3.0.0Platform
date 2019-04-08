using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Login;
using Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Tools;
using ShadowKit;
using UnityEngine;

public class LoginAcountAndPassword:LoginBase {
    public LoginAcountAndPassword() {
        loginType = LoginType.AccountAndPassword;
    }

    public override void Login(string account, string password) {
        base.Login(account,password);

        if (AccountTool.IsError(account)) {
            return;
        }

#if UNITY_ANDROID && !UNITY_EDITOR
		if ( !UserInfo.isLogin()) {
			AndroidConnection.Instance.addListener<LoginAndroidListener> ("setLoginSystemCallback",new LoginAndroidListener());
			//AndroidConnection.Instance.Call ("unityInitCompleted",account,password);
            AndroidConnection.Instance.Call ("unityLoginAndRegister");
            
            AndroidJavaClass PackageManagerClass = new AndroidJavaClass("android.content.pm.PackageManager");
            AndroidJavaObject componentNameObject = AndroidConnection.Instance.Call<AndroidJavaObject>("getComponentName");
            AndroidJavaObject getPackageManagerObject =  AndroidConnection.Instance.Call<AndroidJavaObject>("getPackageManager");
            try {
                AndroidJavaObject ActivityInfoObject =  getPackageManagerObject.Call<AndroidJavaObject>("getActivityInfo", componentNameObject, PackageManagerClass.CallStatic<int>("GET_META_DATA"));
            } catch (Exception e) {
                Debug.Log(e);
            }
            

        }
#else
        UserInfo.Account = "1";
#endif
    }


    //    void OnApplicationFocus(bool hasFocus) {
    //#if UNITY_ANDROID && !UNITY_EDITOR
    //		if (hasFocus && !UserInfo.isLogin()) {
    //			AndroidConnection.Instance.Call ("unityInitCompleted");
    //		}
    //#endif
    //    }

}
