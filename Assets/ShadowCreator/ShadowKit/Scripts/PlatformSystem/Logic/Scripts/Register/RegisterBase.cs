using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.Networking;

namespace Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Register {
    public abstract class RegisterBase {
        public RegisterType registerType;
        /// <summary>
        /// 注册的账户
        /// </summary>
        public string parameter1;
        /// <summary>
        /// 注册的密码
        /// </summary>
        public string parameter2;
        /// <summary>
        /// 注册的方法
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        public virtual void Register(string s1, string s2) {
            parameter1 = s1;
            parameter2 = s2;
        }
    }
}
