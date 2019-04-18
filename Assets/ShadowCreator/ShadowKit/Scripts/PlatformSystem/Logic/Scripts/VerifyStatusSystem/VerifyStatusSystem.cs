using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class VerifyStatusSystem {

    public VerifyItemBase[] VerifyItems = new VerifyItemBase[3] { new VerifyAPP(), new VerifySystemToken() , new VerifyAPPToken() };

    private static VerifyStatusSystem instant;
    private VerifyStatusSystem() { }
    public static VerifyStatusSystem Instant {
        get {
            if (instant == null) {
                instant = new VerifyStatusSystem();
            }
            return instant;
        }
    }

    
    /// <summary>
    /// 系统验证的策略
    /// </summary>
    IVerifyStrategy mVerifyStrategy;
    public void SetVerifyStrategy(IVerifyStrategy verifyStrategy) {
        mVerifyStrategy = verifyStrategy;
    }

    /// <summary>
    /// per frame invoke
    /// </summary>
    public void OnUpdate() {
        if (mVerifyStrategy != null) {
            mVerifyStrategy.OnUpdate(VerifyItems);
        }
    }
    
}