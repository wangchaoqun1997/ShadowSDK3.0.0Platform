using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class LoginPhoneAndVerificationCodeUI : LoginBaseUI {
    public LoginPhoneAndVerificationCodeUI() {
        loginUIType = LoginUIType.PhoneAndVerificationCode;
    }

    public override void Login() {
        ///输入参数检查
        if (loginNameInputField.textCompontent.text == String.Empty || loginPasswordInputField.textCompontent.text == String.Empty) {
            //TODO  PopupUIManager.popupUI.SetInfo("用户名或密码不能为空");
            PlatformUISystem.Instant.uiPanelsManager.PushUIPanel(UIPanelsType.InfoType1Panel, "手机号或验证码不能为空");
            return;
        }
 //       LoginSystem.SetStrategy(new LoginPhoneAndVerificationCode());
  //      LoginManager.Login(loginNameInputField.textCompontent.text, loginPasswordInputField.textCompontent.text);
    }
}
