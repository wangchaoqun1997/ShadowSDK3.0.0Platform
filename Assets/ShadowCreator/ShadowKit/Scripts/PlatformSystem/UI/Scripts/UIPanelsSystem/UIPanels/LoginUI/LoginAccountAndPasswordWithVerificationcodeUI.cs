using DG.Tweening;
using LitJson;
using ShadowKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class LoginAccountAndPasswordWithVerificationcodeUI : LoginBaseUI {

    public SCInputField Verificationcode;
    public Image VerificationcodeImage;

    public LoginAccountAndPasswordWithVerificationcodeUI() {
        Debug.Log("LoginAccountAndPasswordUI");
        loginUIType = LoginUIType.AccountAndPassword;
    }
    /// <summary>
    /// 第一步 GetSessionID
    /// 第二步 获取验证码
    /// 第三步 调登录接口
    /// </summary>
    /// <param name="s"></param>
    public override void Login() {
        ///输入参数检查
        if (loginNameInputField.textCompontent.text == String.Empty || loginPasswordInputField.textCompontent.text == String.Empty) {
            //TODO  PopupUIManager.popupUI.SetInfo("用户名或密码不能为空");

            PlatformUISystem.Instant.uiPanelsManager.PushUIPanel(UIPanelsType.InfoType1Panel, "用户名或密码不能为空");

            //return;
        }

        WWWForm form = new WWWForm();
        form.AddField("session_id", SysInfo.sessionId);
        form.AddField("code", Verificationcode.textCompontent.text);
        form.AddField("loginstr", loginNameInputField.textCompontent.text);
        form.AddField("password", loginPasswordInputField.textCompontent.text);
        //form.AddField("loginstr", "18918690343");
        //form.AddField("password", "wang89c51");
        WebRequestSystem.Instant.Login(LoginSuccess, LoginFailed,form);

    }
    

    public void LoginSuccess(JsonData responseJsonData) {
        SysInfo.SetSysInfo(responseJsonData);
        PlatformUISystem.Instant.uiPanelsManager.PopAllUIPanel();
        PlatformUISystem.Instant.uiPanelsManager.PushUIPanel(UIPanelsType.InfoType1Panel, "LoginSuccess");
    }
    public void LoginFailed(JsonData responseJsonData) {
        PlatformUISystem.Instant.uiPanelsManager.PushUIPanel(UIPanelsType.InfoType1Panel, responseJsonData["message"].ToString());
        RefreshVerificationCode();
    }



    public void GetSessionIDSuccess(JsonData responseJsonData) {
        SysInfo.sessionId = responseJsonData["session_id"].ToString();
        RefreshVerificationCode();
    }

    public void GetSessionIDFailed(JsonData responseJsonData) {
        //PlatformUISystem.Instant.uiPanelsManager.PushUIPanel(UIPanelsType.InfoType1Panel, "ERROR: Get APPToken Error");

    }
    
    public override void OnEnter(object parameter = null) {
        base.OnEnter();
        WebRequestSystem.Instant.GetSessionId(GetSessionIDSuccess, GetSessionIDFailed);
    }

    public void RefreshVerificationCode() {
        WebRequestSystem.Instant.GetVerificationCode(GetVerificationCodeSuccess);
    }

    public void GetVerificationCodeSuccess(byte[] responseStringData) {
        Texture2D targetTexturePre = new Texture2D(120, 50);
        targetTexturePre.LoadImage(responseStringData);
        Sprite temp = Sprite.Create(targetTexturePre, new Rect(0, 0, targetTexturePre.width, targetTexturePre.height), new Vector2(0, 0));
        VerificationcodeImage.sprite = temp;
    }


}
