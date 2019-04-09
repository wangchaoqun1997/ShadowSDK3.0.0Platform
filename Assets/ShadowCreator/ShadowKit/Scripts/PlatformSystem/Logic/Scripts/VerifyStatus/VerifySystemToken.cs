using Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Logic.Scripts.Login;
using Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Logic.Scripts.Model;
using Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Logic.Scripts.VerifyStatus;
using Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Login;
using Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Tools.Web;
using Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.UI.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Tools.VerifySystemToken {
    public class VerifySystemToken {

        //public static Action<object> VerifySystemTokenSuccess;
        //public static Action<object> VerifySystemTokenFailed;

        //public static void VerifySystemToken(Action<object> success=null, Action<object> failed = null) {
        //    VerifySystemTokenSuccess = success;
        //    VerifySystemTokenFailed = failed;
        //    Debug.Log("VerifyToken :VerifySystemToken");
        //    //ToDO调用java

        //    VerifySystemTokenFailedCallBack(null);

        //}

        //private static void VerifySystemTokenOKCallBack(string token,string exp) {
        //    if (VerifySystemTokenSuccess!=null) {
        //        VerifySystemTokenSuccess(token);
        //    }
        //}


        //private static void VerifySystemTokenFailedCallBack(object parm) {
        //    if (VerifySystemTokenFailed != null) {
        //        VerifySystemTokenFailed(parm);
        //    }
        //}

        public static void Start() {
            Debug.Log("VerifySystemToken :VerifySystemToken");

            if (SysInfo.systemTokenExpireTime == 0) {
                //ToDO调用java
                VerifySystemTokenFailedCallBack(null);
            } else if (SysInfo.systemTokenExpireTime > 0) {
                if (true) {//时间过期
                    //ToDO调用java

                    return;
                }
                //系统token没问题

            }

        }
        private static void VerifySystemTokenOKCallBack(string token, float exp) {
            Debug.Log("VerifySystemToken :VerifySystemTokenSuccess");

            SysInfo.systemToken = token;
            SysInfo.systemTokenExpireTime = exp;
            SysInfo.isTokenLegal = true;
        }


        private static void VerifySystemTokenFailedCallBack(object parm) {
            Debug.Log("VerifySystemToken :VerifySystemTokenFailed");
            //PlatformUISystem.Instant.uiPanelsManager.PushUIPanel(UIPanelsType.InfoType1Panel, "ERROR: Get SysToken Error");

            SysInfo.isTokenLegal = false;
            SysInfo.systemToken = null;
            SysInfo.systemTokenExpireTime = 0;

            LoginManager.SetLoginType(new LoginDefault());
            LoginManager.Login();

            //假设登录后成功
            VerifySystemTokenOKCallBack("xxxxx",10000);
        }
    }
}
