using LitJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class AppInfo {
    

    public static string APPID;
    public static string APPKEY;
   

    public static void ResetAppInfo() {
        APPToken = null;
        AppTokenExpireTime = 0;
    }
    public static void SetAppInfo(JsonData responseJsonData) {
        APPToken = responseJsonData["data"]["app_token"].ToString();
        AppTokenExpireTime = double.Parse(responseJsonData["data"]["token_expire_time"].ToString());
        
    }


    public static bool isAPPLegal { get; private set; }
    private static string mAPPToken;
    public static string APPToken {
        get { return mAPPToken; }
        set {
            mAPPToken = value;
            isAPPLegal = true;
            if (mAPPToken == null) {
                isAPPLegal = false;
            }
        }
    }

    private static DateTime mDateTimeWhenGetToken;
    private static double mAppTokenExpireTime;
    public static double AppTokenExpireTime {
        get { return mAppTokenExpireTime; }
        set {
            mAppTokenExpireTime = value;
            if (value != 0) {
                mDateTimeWhenGetToken = DateTime.Now;
            }

        }
    }

    public static bool IsTokenValid() {
        DebugMy.Log("AppInfo IsTokenValid", null);
        ///APPTokenExpireTime为0时 过期
        if (AppTokenExpireTime == 0)
            return false;

        TimeSpan span = (TimeSpan)(DateTime.Now - mDateTimeWhenGetToken);
        return (span.TotalMilliseconds > AppTokenExpireTime) ? false : true;
    }
}
