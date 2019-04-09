using Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Tools.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Logic.Scripts.VerifyStatus {
    public class VerifyAPPToken {

        public static void Start() {
            Debug.Log("VerifyAPPToken :VerifySystemToken");
            WWWForm form = new WWWForm();
            WebRequestBase wq = new WebRequestGetAppToken(form);
            WebRequestManager.Instant.AddWebRequest(wq);
        }
    }
}
