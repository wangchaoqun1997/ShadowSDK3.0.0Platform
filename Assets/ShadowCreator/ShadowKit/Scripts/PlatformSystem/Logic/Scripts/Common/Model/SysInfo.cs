using LitJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class SysInfo {



    public static bool isTokenLegal { get; private set; }
    private static string mSystemToken;
    public static string SystemToken {
        get { return mSystemToken; }
        set {
            mSystemToken = value;
            isTokenLegal = true;
            if (mSystemToken == null) {
                isTokenLegal = false;
            }
        }
    }

    private static DateTime mDateTimeWhenGetToken;
    private static double mSystemTokenExpireTime;
    public static double SystemTokenExpireTime {
        get { return mSystemTokenExpireTime; }
        set {
            
            mSystemTokenExpireTime = value;
            if (value != 0) {
                mDateTimeWhenGetToken = DateTime.Now;
            }
            
        }
    }

    public static string sessionId;
    public static string SN;


    public static void SetSysInfo(JsonData jsonData) {
        SystemToken = jsonData["token"].ToString();
        SystemTokenExpireTime = int.Parse(jsonData["token_expire_time"].ToString());
        //sessionId = jsonData["session_id"].ToString();

        ///TODO 存到文件系统
    }

    public static void ResetSysInfo() {
        SystemToken = null;
        SystemTokenExpireTime = 0;
        sessionId = null;

        ///TODO 从文件系统清除
    }


    public static bool IsTokenValid() {
        DebugMy.Log("SysInfo IsTokenValid", null);
        ///SystemTokenExpireTime为0时 过期
        if (SystemTokenExpireTime == 0)
            return false;

        TimeSpan span = (TimeSpan)(DateTime.Now - mDateTimeWhenGetToken);
        return (span.TotalMilliseconds > mSystemTokenExpireTime) ? false:true;
    }
}