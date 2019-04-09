using Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Logic.Scripts.Login.AndroidListener {
    public interface IAndroidListener {
        void RegisterObservers(Action<object>  sucess=null,Action<object> failed=null);
    }
}
