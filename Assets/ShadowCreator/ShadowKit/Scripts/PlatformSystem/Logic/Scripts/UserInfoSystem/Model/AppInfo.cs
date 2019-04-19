using LitJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class AppInfo {
    

    public string APPID;
    public string APPKEY;
   

    public void ResetAppInfo() {
        APPToken = null;
        AppTokenExpireTime = 0;
    }
    public void SetAppInfo(JsonData responseJsonData) {
        APPToken = responseJsonData["data"]["app_token"].ToString();
        AppTokenExpireTime = double.Parse(responseJsonData["data"]["token_expire_time"].ToString());
        
    }

    
    private string mAPPToken;
    public string APPToken {
        get { return mAPPToken; }
        set {
            mAPPToken = value;
        }
    }

    private DateTime mDateTimeWhenGetToken;
    private double mAppTokenExpireTime;
    public double AppTokenExpireTime {
        get { return mAppTokenExpireTime; }
        set {
            mAppTokenExpireTime = value;
            if (value != 0) {
                mDateTimeWhenGetToken = DateTime.Now;
            }

        }
    }

    public bool IsTokenValid() {
        DebugMy.Log("AppInfo IsTokenValid", null);
        ///APPTokenExpireTime为0时 过期
        if (AppTokenExpireTime == 0)
            return false;

        TimeSpan span = (TimeSpan)(DateTime.Now - mDateTimeWhenGetToken);
        return (span.TotalMilliseconds > AppTokenExpireTime) ? false : true;
    }
}
