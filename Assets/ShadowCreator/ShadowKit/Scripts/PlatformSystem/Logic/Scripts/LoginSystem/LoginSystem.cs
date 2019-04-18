using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class LoginSystem {

    public static string LOGTAG = "[LoginSystem]:";
    
    private static LoginStrategyBase mLoginStrategy;

    public static void SetStrategy(LoginStrategyBase loginStrategy) {
        mLoginStrategy = loginStrategy;
        if (mLoginStrategy != null) {
            mLoginStrategy.RegisterCallBack(Sucess, Failed);
        }
    }

    public static void Login(params string[] s) {
        mLoginStrategy.Login(s);
    }
    

    /// <summary>
    /// CallBack
    /// </summary>
    /// <param name="parm"></param>
    public static void Sucess(object parm) {

    }

    /// <summary>
    /// CallBack
    /// </summary>
    /// <param name="parm"></param>
    public static void Failed(object parm) {

    }
    
}