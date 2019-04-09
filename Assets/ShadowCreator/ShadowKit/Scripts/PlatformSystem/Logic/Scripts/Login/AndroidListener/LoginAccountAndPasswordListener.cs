using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Logic.Scripts.Login.AndroidListener {
    class LoginAccountAndPasswordListener : AndroidJavaProxy, IAndroidListener {
        public void RegisterObservers(Action<object> sucess = null, Action<object> failed = null) {
            throw new NotImplementedException();
        }

        public LoginAccountAndPasswordListener() : base("com.invision.unity.callback.LoginSystemCallback") {
        }
    }
}
