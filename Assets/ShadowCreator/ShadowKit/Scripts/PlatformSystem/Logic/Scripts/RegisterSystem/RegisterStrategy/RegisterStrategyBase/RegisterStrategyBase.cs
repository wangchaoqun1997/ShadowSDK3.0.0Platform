using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public abstract class RegisterStrategyBase {

    /// <summary>
    /// 注册的具体策略方法
    /// </summary>
    /// <param name="s"></param>
    public abstract void Register(params string[] s);

    /// <summary>
    /// 注册后的回调注册方法
    /// </summary>
    /// <param name="sucess"></param>
    /// <param name="failed"></param>
    public abstract void RegisterCallBack(Action<object> sucess = null, Action<object> failed = null);


}