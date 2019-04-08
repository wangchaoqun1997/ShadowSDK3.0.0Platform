using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Login {
    public abstract class LoginBase {

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
            param1 = s1;
            param2 = s2;
        }

    }
}
