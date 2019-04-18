using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class LoginAccountAndPasswordUI : LoginBaseUI {

    public LoginAccountAndPasswordUI() {
        Debug.Log("LoginAccountAndPasswordUI");
        loginUIType = LoginUIType.AccountAndPassword;
    }

    public override void Login() {
        ///输入参数检查
        if (loginNameInputField.textCompontent.text == String.Empty || loginPasswordInputField.textCompontent.text == String.Empty) {
            //TODO  PopupUIManager.popupUI.SetInfo("用户名或密码不能为空");

            PlatformUISystem.Instant.uiPanelsManager.PushUIPanel(UIPanelsType.InfoType1Panel, "用户名或密码不能为空");

            return;
        }
        LoginSystem.SetStrategy(new LoginStrategyAccountAndPasswordFrowJava());
        LoginSystem.Login(loginNameInputField.textCompontent.text, loginPasswordInputField.textCompontent.text);
    }

    public override void OnEnter(object parameter = null) {
        base.OnEnter();
        canvasGroup.alpha = 0;
        canvasGroup.DOFade(1, .5f);
    }
}
