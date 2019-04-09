using Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.UI.Scripts;
using Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.UI.Scripts.UIPanels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 管理登录支付等UI
/// </summary>
public class PlatformUISystem: MonoBehaviour {

    public const string LOGTAG = "[PlatformUIController]:";
    public static PlatformUISystem Instant;
    public UIPanelsManager uiPanelsManager;

    void Awake() {
        if (Instant != null) {
            DestroyImmediate(gameObject);
            return;
        }
        
        DontDestroyOnLoad(gameObject);
        Instant = this;
        uiPanelsManager = new UIPanelsManager(true);
        
    }

    void Start() {
        //uiPanelsManager.PushUIPanel(UIPanelsType.LoginAccountAndPasswordPanel);
    }
}
