﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfo {

    public static int id;
    public static string username;
    public static string nickname;
    public static string email;
    public static int emailCheck;
    public static string phone;

    public static string Serialno =  string.Empty;
	public static string Account = string.Empty;
	public static string AppID = string.Empty;
   
	/// <summary>
	/// 判断是否为游客账号
	/// </summary>
	/// <returns><c>true</c>, if vistor account was ised, <c>false</c> otherwise.</returns>
	public static bool isVistorAccount()
	{
		return Serialno == Account;
	}
	/// <summary>
	/// 判断用户是否登陆
	/// </summary>
	/// <returns><c>true</c>, if login was ised, <c>false</c> otherwise.</returns>
	public static bool isLogin()
	{
		return Account != string.Empty;
	}
}
