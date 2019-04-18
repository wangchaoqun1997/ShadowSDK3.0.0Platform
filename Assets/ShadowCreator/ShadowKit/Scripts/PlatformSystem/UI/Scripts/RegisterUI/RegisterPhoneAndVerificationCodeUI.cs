using Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class RegisterPhoneAndVerificationCodeUI : RegisterBaseUI {
    public override void Register() {
        ///输入参数检查
        if (nameInputField.textCompontent.text == string.Empty) {
            //TODO PopupUIManager.popupUI.SetInfo("邮箱名不能为空");
            PlatformUISystem.Instant.uiPanelsManager.PushUIPanel(UIPanelsType.InfoType1Panel, "手机号不能为空");
            return;
        }
        if (passwordInputField.textCompontent.text == string.Empty) {
            //TODO PopupUIManager.popupUI.SetInfo("邮箱名不能为空");
            PlatformUISystem.Instant.uiPanelsManager.PushUIPanel(UIPanelsType.InfoType1Panel, "密码不能为空");
            return;
        }
        if (rePasswordInputField.textCompontent.text == string.Empty) {
            //TODO PopupUIManager.popupUI.SetInfo("邮箱名不能为空");
            PlatformUISystem.Instant.uiPanelsManager.PushUIPanel(UIPanelsType.InfoType1Panel, "密码不能为空");
            return;
        }

        ///输入参数检查
        if (passwordInputField.textCompontent.text != rePasswordInputField.textCompontent.text) {
            //TODO PopupUIManager.popupUI.SetInfo("密码不统一");
            PlatformUISystem.Instant.uiPanelsManager.PushUIPanel(UIPanelsType.InfoType1Panel, "密码不统一");
            return;
        }

        RegisterManager.SetRegisterType(new RegisterPhoneAndVerificationCode());
        RegisterManager.Register(nameInputField.textCompontent.text, passwordInputField.textCompontent.text);

    }
}
