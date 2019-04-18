using ShadowKit;
using ShadowKit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;

[Serializable]
public abstract class RegisterBaseUI : BaseUIPanel {
    ///// <summary>
    ///// 
    ///// </summary>
    //public Text nameText;

    ///// <summary>
    ///// 
    ///// </summary>
    //public Text passwordText;

    /// <summary>
    /// 
    /// </summary>
    public SCInputField nameInputField;

    /// <summary>
    /// 
    /// </summary>
    public SCInputField passwordInputField;

    /// <summary>
    /// 
    /// </summary>
    public SCInputField rePasswordInputField;

    /// <summary>
    /// 
    /// </summary>
    public SCButton registerButton;

    /// <summary>
    /// 
    /// </summary>
    public SCButton goToLoginButton;

    ///// <summary>
    ///// 
    ///// </summary>
    //public Text info;

    public abstract void Register();
    public virtual void GoToLogin() {
        PlatformUISystem.Instant.uiPanelsManager.PopUIPanel();
        PlatformUISystem.Instant.uiPanelsManager.PushUIPanel(UIPanelsType.LoginAcountAndPasswordPanelWithVerificationcode);
    }
}
