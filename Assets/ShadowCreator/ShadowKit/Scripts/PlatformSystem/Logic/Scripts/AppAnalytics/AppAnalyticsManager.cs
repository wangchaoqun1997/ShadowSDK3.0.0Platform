using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class AppAnalyticsManager {
    public const string TAG = "[AppAnalyticsManager]:";

    public static void Init(string TalkingDataAPPID, string scAppId) {
        TalkingDataPlugin.SetLogEnabled(true);
        TalkingDataPlugin.SetExceptionReportEnabled(true);
        TalkingDataPlugin.SessionStarted(TalkingDataAPPID, scAppId);
        Debug.Log(TAG+"Init");
    }
    public static void SessionStoped() {
        TalkingDataPlugin.SessionStoped();
        Debug.Log(TAG + "Stop");
    }

    public static void OnLogin(string accountId, TalkingDataAccountType type, string name) {
        TalkingDataPlugin.OnLogin(accountId, type, name);
        Debug.Log(TAG + "OnLogin");
    }
    public static void OnRegister(string accountId, TalkingDataAccountType type, string name) {
        TalkingDataPlugin.OnRegister(accountId, type, name);
        Debug.Log(TAG + "OnRegister");
    }
    

}