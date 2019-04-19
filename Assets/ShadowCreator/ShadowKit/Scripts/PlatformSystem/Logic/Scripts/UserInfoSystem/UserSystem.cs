using LitJson;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class UserSystem : MonoBehaviour {

    public AppInfo AppInfo;
    public SysInfo SysInfo;

    //private UserSystem() {
    //    mAppInfo = new AppInfo();
    //    mSysInfo = new SysInfo(new UserNomal());
    //}
    //private static UserSystem instant;
    //public static UserSystem Instant {
    //    get {
    //        if (instant == null) {
    //            instant = new UserSystem();
    //        }
    //        return instant;
    //    }
    //}

    public static UserSystem Instant;
    void Awake() {
        if (Instant != null) {
            DestroyImmediate(this);
            return;
        }
        Instant = this;
        DontDestroyOnLoad(this);

        AppInfo = new AppInfo();
        SysInfo = new SysInfo(new UserNomal());

    }

    ///// <summary>
    ///// sysinfo
    ///// </summary>
    ///// <returns></returns>
    //public bool IsSysTokenValid {
    //    get { return mSysInfo.IsUserTokenValid(); }
    //}
    //public void SetSysInfo(string Account, string Password, JsonData responseJsonData) {
    //    mSysInfo.SetUserInfo(Account, Password, responseJsonData);
    //}
    //public void ResetSysInfo() {
    //    mSysInfo.ResetUserInfo();
    //}
    //public string SysToken {
    //    get { return mSysInfo.UserToken; }
    //}
    //public string SenssionID {
    //    get { return mSysInfo.SessionId; }
    //    set { mSysInfo.SessionId = value; }
    //}


    ///// <summary>
    ///// appinfo
    ///// </summary>
    ///// <returns></returns>
    //public bool IsAppTokenValid {
    //    get { return mAppInfo.IsTokenValid(); }
    //}

    //public void SetAppInfo(JsonData responseJsonData) {
    //    mAppInfo.SetAppInfo(responseJsonData);
    //}
    //public void ResetAppInfo() {
    //    mAppInfo.ResetAppInfo();
    //}
    //public string AppToken {
    //    get { return mAppInfo.APPToken; }
    //}
    //public string AppID {
    //    get { return mAppInfo.APPID; }
    //    set { mAppInfo.APPID = value; }
    //}
    //public string AppKey {
    //    get { return mAppInfo.APPKEY; }
    //    set { mAppInfo.APPKEY = value; }
    //}


    //public string UserUID {
    //    get { return mSysInfo.mUser.Uid; }
    //    set { mSysInfo.mUser.Uid = value; }
    //}
}