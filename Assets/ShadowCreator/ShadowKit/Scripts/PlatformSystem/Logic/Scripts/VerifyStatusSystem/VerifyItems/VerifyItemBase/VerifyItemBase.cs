using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public abstract class VerifyItemBase {

    public VerifyState verifyState {
        get;set;
    }

    /// <summary>
    /// 当状态Failed时，执行的解决方法
    /// </summary>
    public virtual void DoSolve() {
        DebugMy.Log("DoSolve ....",this);
        verifyState = VerifyState.Doning;
    }
    
    /// <summary>
    /// 更新VerifyState的状态
    /// </summary>
    public abstract void OnUpdateVerifyState();
}

