using ShadowKit;
using ShadowKit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;

[Serializable]
public abstract class LoginBaseUI : BaseUIPanel {


    ///// <summary>
    ///// 
    ///// </summary>
    //public Text loginNameText;

    ///// <summary>
    ///// 
    ///// </summary>
    //public Text loginPasswordText;
    public LoginUIType loginUIType;

    /// <summary>
    /// 
    /// </summary>
    public SCInputField loginNameInputField;

    /// <summary>
    /// 
    /// </summary>
    public SCInputField loginPasswordInputField;

    /// <summary>
    /// 
    /// </summary>
    public SCButton loginButton;

    /// <summary>
    /// 
    /// </summary>
    public SCButton goToRegisterButton;

    public abstract void Login();

    public virtual void GoToRegister() {
        PlatformUISystem.Instant.uiPanelsManager.PopUIPanel();
        PlatformUISystem.Instant.uiPanelsManager.PushUIPanel(UIPanelsType.RegisterPhoneAndVerificationCodePanel);
    }


}
