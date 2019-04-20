using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class VerifyStatusSystem {

    public VerifyItemBase[] VerifyItems = new VerifyItemBase[3] { new VerifyAPP() , new VerifySystemToken(), new VerifyAPPToken() };

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
    /// per frame invoke
    /// </summary>
    /// 
    float timer = 0;
    float interval = 5;

    public void OnUpdate() {
        timer += Time.deltaTime;
        if (timer < interval) {
            return;
        }
        timer = 0;
        

        foreach (VerifyItemBase verifyItem in VerifyItems) {

            verifyItem.OnUpdateVerifyState();

            DebugMy.Log(verifyItem.ToString()+": "+verifyItem.verifyState.ToString(), this);

            if (verifyItem.verifyState != VerifyState.Success) {
                if (verifyItem.verifyState != VerifyState.Doning) {
                    verifyItem.DoSolve();
                }
                break;
            }
        }
        
    }
    

}