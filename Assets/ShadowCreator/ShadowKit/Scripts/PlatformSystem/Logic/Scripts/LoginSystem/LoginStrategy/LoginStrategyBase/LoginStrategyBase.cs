using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public abstract class LoginStrategyBase {

    /// <summary>
    /// 登录的具体策略方法
    /// </summary>
    /// <param name="s"></param>
    public abstract void Login(params string[] s);

    /// <summary>
    /// 登录后的回调注册方法
    /// </summary>
    /// <param name="sucess"></param>
    /// <param name="failed"></param>
    public abstract void RegisterCallBack(Action<object> sucess = null, Action<object> failed = null);
    
    
}