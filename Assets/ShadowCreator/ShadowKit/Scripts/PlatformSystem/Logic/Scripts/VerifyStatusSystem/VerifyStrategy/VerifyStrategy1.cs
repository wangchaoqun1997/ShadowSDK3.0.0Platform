using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class VerifyStrategy1 : IVerifyStrategy {

    /// <summary>
    /// 策略1
    /// 按数组顺序依次确认，上一个未确认完，下一个不会开始确认
    /// 每interval s才执行一次策略
    /// </summary>
    /// <param name="verifyItems"></param>
    /// 
    float timer = 0;
    float interval = 5;
    public override void OnUpdate(VerifyItemBase[] verifyItems) {
        timer += Time.deltaTime;
        if (timer < interval) {
            return;
        }
        timer = 0;

        
        foreach (VerifyItemBase verifyItem in verifyItems) {

            verifyItem.OnUpdate();

            if (verifyItem.verifyState != VerifyState.Success) {

                if (verifyItem.verifyState != VerifyState.Doning) {
                    DebugMy.Log(verifyItem.ToString(), this);
                    verifyItem.DoVerify();
                }
                break;
            }
        }
    }


}