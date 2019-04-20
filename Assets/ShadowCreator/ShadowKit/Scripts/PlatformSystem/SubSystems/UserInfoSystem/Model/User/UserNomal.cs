using System;
using System.Collections.Generic;
using System.Text;
using LitJson;
using ShadowKit;
using UnityEngine;

public class UserNomal :UserBase{

    public UserNomal():base(UserType.Nomal) { }



    public override void Init() {

    }


    public override string Account {
        get {
#if UNITY_ANDROID && !UNITY_EDITOR
            account = (account!=null) ? account : AndroidConnection.Instance.Call<string>("unityGetAccount");
#endif   
            return account;
        }
    }


    public override string Password {
        get {
#if UNITY_ANDROID && !UNITY_EDITOR
            password = (password!=null) ? password : AndroidConnection.Instance.Call<string>("getPassword");
#endif
            return password;
        }
    }


    public override string Token {
        get {
#if UNITY_ANDROID && !UNITY_EDITOR
            token =  (token!=null) ? token : AndroidConnection.Instance.Call<string>("unityGetAuthToken");
#endif
            return token;
        }
    }



    public override bool IsTokenVaild() {
        return (Token != null) ? true : false;
    }

    public override void SetUserInfo(object obj, string _account, string _password) {
        JsonData jsonData = obj as JsonData;

        TokenExpireTime = double.Parse(jsonData["token_expire_time"].ToString());
        Email = jsonData["email"].ToString();
        EmailCheck = int.Parse(jsonData["emailcheck"].ToString());
        Phone = jsonData["phone"].ToString();
        Uid = jsonData["uid"].ToString();
        Nickname = jsonData["nickname"].ToString();
        
        ///TODO 存到文件系统
        WriteSysinfoToMemory(_account, _password, jsonData["token"].ToString());

        UserSystem.Instant.SysInfo.mUser.PrintInfo();
    }

    void WriteSysinfoToMemory(string Account, string Password, string Token) {
#if UNITY_ANDROID && !UNITY_EDITOR
        AndroidConnection.Instance.Call("unityLoginAccount", Account, Password, Token);
#endif
    }


    public override void ResetUserInfo() {
        base.ResetUserInfo();

        ///TODO 从文件系统清除
        if (Account != null) {
            ErasureSysinfoInMemeory(Account);
        }
    }

    void ErasureSysinfoInMemeory(string Account) {
#if UNITY_ANDROID && !UNITY_EDITOR
        AndroidConnection.Instance.Call("unityRemoveAccount",Account);
#endif
    }

}