using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class SimulateManager {

    public static void LoginSucess(string account) {
        UserInfo.Account = account;
        AppAnalyticsManager.OnLogin(account, TalkingDataAccountType.WEIXIN, "小狗");
        //PlatformUISystem.Instant.SetPopupInfo("账号密码登录成功");
    }

    public static void LoginFailed() {

    }


    public static void RegisterSucess(string account) {
        AppAnalyticsManager.OnRegister(account, TalkingDataAccountType.QQ, "小猫");
        //PlatformUISystem.Instant.SetPopupInfo("注册成功");
    }


    public static void RegisterFailed() {

    }


}