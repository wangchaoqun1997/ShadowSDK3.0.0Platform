using LitJson;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public abstract class UserBase {


    
    public UserBase(UserType type) {
        userType = type;
    }


    public UserType userType;

    protected string account;
    public virtual string Account {
        get { return account; }
    }

    protected string password;
    public virtual string Password {
        get { return token; }
    }

    protected string token;
    public virtual string Token {
        get { return token; }
    }

    public virtual string SessionId { get; set; }

    public virtual string Uid { get; set; }
    public virtual string Email { get; set; }
    public virtual int EmailCheck { get; set; }
    public virtual string Phone { get; set; }
    public virtual string Nickname { get; set; }

    protected DateTime mDateTimeWhenGetTokenExpireTime;
    private double mTokenExpireTime;
    public virtual double TokenExpireTime {
        set {
            mDateTimeWhenGetTokenExpireTime = DateTime.Now;
            mTokenExpireTime = value;
        }
        get { return mTokenExpireTime; }
    }


    /// <summary>
    /// 方法
    /// </summary>
    public bool IsLogin {
        get { return (Account != null) ? true : false; }
    }

    public virtual void ResetUserInfo() {
        DebugMy.Log("Delect Account !!!",this);
        account = null;
        password = null;
        token = null;

        Uid = null;
        Email = null;
        EmailCheck = 0;
        Phone = null;
        SessionId = null;
        Nickname = null;
        mTokenExpireTime = 0;
    }

    public abstract void Init();
    public virtual void SetUserInfo(object obj,string account,string password) { }

    public virtual bool IsTokenVaild() {
        return false;

    }



    public void PrintInfo() {
        DebugMy.Log(Account + ":" + Password + ":" + Token + ":" + userType, this);
    }


}