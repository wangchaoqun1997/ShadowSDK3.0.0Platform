using Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Logic.Scripts.Login.AndroidListener;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Login {
    public abstract class LoginBase {

        public string LOGTAG = "[LoginBase]:";

        /// <summary>
        /// login登录成功或失败的监听器
        /// </summary>
        public IAndroidListener loginAndroidListener;

        public LoginType loginType;
        /// <summary>
        /// 
        /// </summary>
        public string param1;
        /// <summary>
        /// 
        /// </summary>
        public string param2;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s1">account或者phone</param>
        /// <param name="s2">密码或验证码</param>
        public virtual void Login(string s1, string s2) {
            Debug.Log(LOGTAG+ "Login");
            param1 = s1;
            param2 = s2;
            if (loginAndroidListener != null) {
                loginAndroidListener.RegisterObservers(Sucess, Failed);
            }
        }


       
        public virtual void Sucess(object parm) {
            Debug.Log(LOGTAG + "Sucess");
        }
        public virtual void Failed(object parm) {
            Debug.Log(LOGTAG + "Failed");
        }
    }
}
