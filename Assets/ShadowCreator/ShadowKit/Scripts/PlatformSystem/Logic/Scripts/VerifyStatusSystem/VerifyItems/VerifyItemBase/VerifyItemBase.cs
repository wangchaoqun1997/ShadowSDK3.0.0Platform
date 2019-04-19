using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public abstract class VerifyItemBase {
    public VerifyState verifyState {
        get;set;
    }

    /// <summary>
    /// 模板模式，执行验证
    /// </summary>
    public void DoVerify() {
        DebugMy.Log("DoVerify", this);
        PreDoVerify();
        DoVerifyStart();
    }

    public virtual void PreDoVerify() {
        verifyState = VerifyState.Doning;
    }
    public abstract void DoVerifyStart();


    /// <summary>
    /// 更新VerifyState的状态
    /// </summary>
    public abstract void OnUpdate();
}