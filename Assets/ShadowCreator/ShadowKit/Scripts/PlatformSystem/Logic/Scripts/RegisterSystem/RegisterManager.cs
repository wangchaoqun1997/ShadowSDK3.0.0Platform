using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Register {
    class RegisterManager {
        public static RegisterBase register;

        public static void SetRegisterType(RegisterBase _registerType) {
            register = _registerType;
        }
        public static void SetRegisterType(RegisterType _registerType) {
            if (_registerType == RegisterType.PhoneAndVerificationCode) {
                register = new RegisterPhoneAndVerificationCode();
            } else if (_registerType == RegisterType.EmailAndVerificationCode) {
                register = new RegisterEmailAndVerificationCode();
            }
        }

        public static void Register(string s1, string s2) {
            if (register == null) {
                Debug.Log("Muse init register");
                return;
            }

            register.Register(s1, s2);
        }
    }
}
