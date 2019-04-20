using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class RegisterSystem {
    public static string LOGTAG = "[RegisterSystem]:";

    private static RegisterStrategyBase mRegisterStrategy;

    public static void SetStrategy(RegisterStrategyBase registerStrategy) {
        mRegisterStrategy = registerStrategy;
        if (mRegisterStrategy != null) {
            mRegisterStrategy.RegisterCallBack(Sucess, Failed);
        }
    }

    public static void Register(params string[] s) {
        mRegisterStrategy.Register(s);
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
