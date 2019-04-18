using LitJson;
using ShadowKit;
using ShadowKit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

class RegisterPhoneAndVerificationCodeUI : RegisterBaseUI {

    float DisabledTime;
    public SCButton GetVerificationCodeButton;
    private BoxCollider GetVerificationCodeButtonCollider;
    public Text GetVerificationCodeButtonText;
    public SCInputField VerificationCodeInputField;

    public override void OnEnter(object parameter = null) {
        base.OnEnter(parameter);
        nameInputField.textCompontent.text = null;
        passwordInputField.textCompontent.text = null;
        VerificationCodeInputField.textCompontent.text = null;
    }

    public override void Register() {
        ///输入参数检查
        if (nameInputField.textCompontent.text == string.Empty) {
            PlatformUISystem.Instant.uiPanelsManager.PushUIPanel(UIPanelsType.InfoType1Panel, "手机号不能为空");
            return;
        }
        if (passwordInputField.textCompontent.text == string.Empty) {
            PlatformUISystem.Instant.uiPanelsManager.PushUIPanel(UIPanelsType.InfoType1Panel, "密码不能为空");
            return;
        }
        if (VerificationCodeInputField.textCompontent.text == string.Empty) {
            PlatformUISystem.Instant.uiPanelsManager.PushUIPanel(UIPanelsType.InfoType1Panel, "验证码不能为空");
            return;
        }

        /////输入参数检查
        //if (passwordInputField.textCompontent.text != rePasswordInputField.textCompontent.text) {
        //    //TODO PopupUIManager.popupUI.SetInfo("密码不统一");
        //    PlatformUISystem.Instant.uiPanelsManager.PushUIPanel(UIPanelsType.InfoType1Panel, "密码不统一");
        //    return;
        //}

        WWWForm form = new WWWForm();
        form.AddField("phone", nameInputField.textCompontent.text);
        form.AddField("password", passwordInputField.textCompontent.text);
        form.AddField("code", VerificationCodeInputField.textCompontent.text);
        form.AddField("type", 1);
        //form.AddField("phone", "17702187097");
        //form.AddField("password", "wang123456");
        //form.AddField("type", 1);
        //form.AddField("code", VerificationCodeInputField.textCompontent.text);
        WebRequestSystem.Instant.GetRegisterPhoneVerificationcode(RegisterSuccess, RegisterFailed, form);

    }

    /// <summary>
    /// 注册成功回调
    /// </summary>
    /// <param name="responseStringData"></param>
    public void RegisterSuccess(JsonData responseStringData) {
        PlatformUISystem.Instant.uiPanelsManager.PopAllUIPanel();
        PlatformUISystem.Instant.uiPanelsManager.PushUIPanel(UIPanelsType.InfoType1Panel,"注册成功");
    }
    /// <summary>
    /// 注册失败回调
    /// </summary>
    /// <param name="responseStringData"></param>
    public void RegisterFailed(JsonData responseStringData) {
        PlatformUISystem.Instant.uiPanelsManager.PushUIPanel(UIPanelsType.InfoType1Panel, responseStringData["message"].ToString());
    }



    /// <summary>
    /// 获取验证码
    /// </summary>
    public void RefreshVerificationCode() {
        WWWForm form = new WWWForm();
        form.AddField("phone", nameInputField.textCompontent.text);
        form.AddField("type", 1);
        WebRequestSystem.Instant.GetRegisterPhoneVerificationcode(GetRegisterPhoneVerificationcodeSuccess, GetRegisterPhoneVerificationcodeFailed, form);
    }


    /// <summary>
    /// 获取验证码成功回调
    /// </summary>
    public void GetRegisterPhoneVerificationcodeSuccess(JsonData responseStringData) {
        SetDisabledTime(60);
    }
    /// <summary>
    /// 获取验证码失败回调
    /// </summary>
    /// <param name="responseStringData"></param>
    public void GetRegisterPhoneVerificationcodeFailed(JsonData responseStringData) {
        PlatformUISystem.Instant.uiPanelsManager.PushUIPanel(UIPanelsType.InfoType1Panel, responseStringData["message"].ToString());
    }


    void Start() {
        GetVerificationCodeButtonCollider = GetVerificationCodeButton.GetComponent<BoxCollider>();

    }

    void Update() {
        OnUpdateVerificationCodeButton();
    }


    void OnUpdateVerificationCodeButton() {
        
        DisabledTime -= Time.deltaTime;
        if ((DisabledTime) <= 0) {
            DisabledTime = 0;
            DisableGetPhoneVerificationCodeButton(false);
        } else{
            GetVerificationCodeButtonText.text = ((int)DisabledTime).ToString() + " S 后重试";
        }
    }
    void SetDisabledTime(float time) {
        DisabledTime = time;
        DisableGetPhoneVerificationCodeButton(true);
    }

    void DisableGetPhoneVerificationCodeButton(bool isDisable) {
        if (isDisable == true) {
            GetVerificationCodeButtonCollider.enabled = false;
        } else {
            GetVerificationCodeButtonCollider.enabled = true;
            GetVerificationCodeButtonText.text = "获取验证码";
        }
    }

}

