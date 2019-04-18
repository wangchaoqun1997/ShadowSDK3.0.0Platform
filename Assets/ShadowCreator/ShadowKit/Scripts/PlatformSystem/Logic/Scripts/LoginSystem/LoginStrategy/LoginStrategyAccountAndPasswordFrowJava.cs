using ShadowKit;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class LoginStrategyAccountAndPasswordFrowJava : LoginStrategyBase {


    public override void Login(params string[] s) {
        if (s[0] != null && s[1] != null) {
            Debug.Log("Error :account or password must have a value");
        }
#if UNITY_ANDROID && !UNITY_EDITOR
        AndroidConnection.Instance.Call("unityLoginAccount", s[0], s[1]);
#endif
    }

    public override void RegisterCallBack(Action<object> sucess = null, Action<object> failed = null) {
#if UNITY_ANDROID && !UNITY_EDITOR
        AndroidConnection.Instance.addListener<LoginAccountAndPasswordFrowJavaCallBack>("setLoginSystemCallback", new LoginAccountAndPasswordFrowJavaCallBack(sucess,failed));
#endif
    }

    /// <summary>
    /// Java CallBack
    /// </summary>
    public class LoginAccountAndPasswordFrowJavaCallBack : AndroidJavaProxy {

        protected Action<object> mSucess;
        protected Action<object> mFailed;

        public LoginAccountAndPasswordFrowJavaCallBack(Action<object> sucess = null, Action<object> failed = null) : base("com.invision.unity.callback.LoginSystemCallback") {
            mSucess = sucess;
            mFailed = failed;
        }
        

        public void onLoginSuccess(string accountName) {
            if (mSucess != null) {
                mSucess(accountName);
            }

        }

        public void onLoginFailed(string msg) {
            if (mFailed != null) {
                mFailed(msg);
            }
        }


        ///// 以下老代码
        //public void onInitSerialno(string serialno) {
        //    Debug.Log("LoginListener.onInitSerialno=====>" + serialno);
        //    SysInfo.SN = serialno;
        //}

        //public void onInitAccountName(string serialno) {
        //    Debug.Log("LoginListener.onInitAccountName=====>" + serialno);

        //    if (serialno == string.Empty) {
        //        unityLoginAndRegister();
        //        UserInfo.Account = string.Empty;
        //    } else {
        //        UserInfo.Account = serialno + "";
        //        //支付测试
        //        //ShadowSystem.PaySystem.pay ("10001", 1, PayType.WEIXIN, payCallback);
        //    }
        //}

        //private void payCallback(string msg) {
        //    Debug.Log("Paysystem.payCallback========>" + msg);
        //}



        ////如果没有影创账户则调用sdk注册方法
        //public void unityLoginAndRegister() {
        //    Debug.Log("LoginListener.unityLoginAndRegister=====>");
        //    AndroidConnection.Instance.Call("unityLoginAndRegister");
        //}


    }
}