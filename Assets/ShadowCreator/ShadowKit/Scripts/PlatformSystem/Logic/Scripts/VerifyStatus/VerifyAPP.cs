using Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Logic.Scripts.Model;
using Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Tools.VerifySystemToken;
using Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.UI.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Logic.Scripts.VerifyStatus {
    public class VerifyAPP {

        //public static Action<object> VerifyAPPSuccess;
        //public static Action<object> VerifyAPPFailed;

        //public static void VeriftyStart(Action<object> success = null, Action<object> failed = null) {
        //    VerifyAPPSuccess = success;
        //    VerifyAPPFailed = failed;
        //    Debug.Log("VerifyToken :VerifySystemToken");
        //    //ToDO调用java

        //    VerifyAPPFailedCallBack(null);

        //}

        //private static void VerifyAPPOKCallBack(string token, string exp) {
        //    if (VerifyAPPSuccess != null) {
        //        VerifyAPPSuccess(token);
        //    }
        //}


        //private static void VerifyAPPFailedCallBack(object parm) {
        //    if (VerifyAPPFailed != null) {
        //        VerifyAPPFailed(parm);
        //    }
        //}

        public static void Start() {
            Debug.Log("VerifyAPP :VerifySystemToken");
            //GetAPPID GETAPPKEY;
            AppInfo.APPID = "";
            AppInfo.APPKEY = "";

            //ToDO调用java
            //VerifyAPPOKCallBack();
           VerifyAPPFailedCallBack();
        }

        private static void VerifyAPPOKCallBack() {
            Debug.Log("VerifyAPP :VerifyAPPSuccess");
            //APP合法
            AppInfo.isAPPLegal = true;

        }


        private static void VerifyAPPFailedCallBack() {
            Debug.Log("VerifyAPP :VerifyAPPFailed");
            //App非法
            AppInfo.isAPPLegal = false;

            PlatformUISystem.Instant.uiPanelsManager.PushUIPanel(UIPanelsType.InfoType1Panel, "ERROR:APPID and APPKey Illegal");
           // Application.Quit();
        }
    }
}
