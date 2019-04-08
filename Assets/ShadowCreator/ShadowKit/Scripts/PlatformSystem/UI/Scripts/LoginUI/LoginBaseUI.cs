using ShadowKit;
using ShadowKit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;

namespace Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.UI.LoginUI {
    [Serializable]
    public abstract class LoginBaseUI : BaseUIPanel {

        /// <summary>
        /// UI Type
        /// </summary>
        [NonSerialized]
        public LoginUIType loginUIType;

        ///// <summary>
        ///// 
        ///// </summary>
        //public Text loginNameText;
        
        ///// <summary>
        ///// 
        ///// </summary>
        //public Text loginPasswordText;
        
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
            PlatformUISystem.Instant.uiPanelsManager.PushUIPanel(Scripts.UIPanelsType.RegisterPhoneAndVerificationCodePanel);
        }
        

    }
}
