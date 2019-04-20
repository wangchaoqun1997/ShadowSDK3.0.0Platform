using LitJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class SysInfo {


    public UserBase mUser;
    public string SN { get; set; }
    
    /// <summary>
    /// 初始化,默认创建Nomal用户：需要账户密码的用户
    /// </summary>
    public SysInfo(UserBase user = null) {

        ///TODO  SN获取
        

        if (user == null) {
            mUser = new UserNomal();
            return;
        }
        mUser = user;
    }

    public void SetUser(UserBase user) {
        mUser = user;
    }

    /// <summary>
    /// 获取UserToken  (系统token)
    /// </summary>
    public  string UserToken {
        get { return mUser.Token; }
    }

    public string SessionId {
        get { return mUser.SessionId; }
        set { mUser.SessionId = value; }
    }

    /// <summary>
    /// 设置登录信息
    /// </summary>
    /// <param name="Account"> 账户名 </param>
    /// <param name="Password"> 密码 </param>
    /// <param name="jsonData"> 其它数据 </param>
    public  void SetUserInfo(JsonData jsonData,string account, string password) {
        mUser.SetUserInfo(jsonData, account,password);
    }

    /// <summary>
    /// 注销登录信息
    /// </summary>
    public void ResetUserInfo() {
        mUser.ResetUserInfo();
    }
    
    /// <summary>
    /// 登录是否过时判断
    /// </summary>
    /// <returns></returns>
    public bool IsUserTokenValid {
        get { return mUser.IsTokenVaild(); }
    }
}