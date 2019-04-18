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
        PreEnter();
        Start();
    }

    public virtual void PreEnter() {
        verifyState = VerifyState.Doning;
    }
    public abstract void Start();
    public virtual void Exit() { }

    /// <summary>
    /// 更新VerifyState的状态
    /// </summary>
    public abstract void OnUpdate();
}