using Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Logic.Scripts.Login.AndroidListener;
using Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Logic.Scripts.Model;
using Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Login;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShadowKit
{
	public class LoginDefaultListener : AndroidJavaProxy, IAndroidListener {



        private System.Action<object> mSucess;
        private System.Action<object> mFailed;

        public void RegisterObservers(System.Action<object> sucess, System.Action<object> failed) {
            mSucess = sucess;
            mFailed = failed;
        }
        
        public LoginDefaultListener(): base("com.invision.unity.callback.LoginSystemCallback")  
		{
		}

        public void onInitSerialno(string serialno)
		{
			Debug.Log ("LoginListener.onInitSerialno=====>" + serialno);
			SysInfo.SN = serialno;
		}

		public void onInitAccountName(string serialno)
		{
			Debug.Log ("LoginListener.onInitAccountName=====>" + serialno);

			if (serialno == string.Empty ) {
				unityLoginAndRegister ();
				UserInfo.Account = string.Empty;
			} else {
				UserInfo.Account = serialno+"";
				//支付测试
				//ShadowSystem.PaySystem.pay ("10001", 1, PayType.WEIXIN, payCallback);
			}
		}

		private void payCallback(string msg)
		{			
			Debug.Log ("Paysystem.payCallback========>" + msg);
		}
		public void onLoginSuccess(string accountName)
		{
            if (mSucess != null) {
                mSucess(accountName);
            }
			
		}

		public void onLoginFailed(string msg)
		{
            if (mFailed != null) {
                mFailed(msg);
            }
		}


		//如果没有影创账户则调用sdk注册方法
		public void unityLoginAndRegister()
		{
			Debug.Log ("LoginListener.unityLoginAndRegister=====>");
			AndroidConnection.Instance.Call ("unityLoginAndRegister");
		}

    }
}

