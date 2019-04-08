using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ShadowKit;
using UnityEngine.UI;
using Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Login;
using Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Register;

public class PlatformLogicSystem : MonoBehaviour {

    public const string LOGTAG = "[PlatformSystem]:";

    public static PlatformLogicSystem Instant;
    
    /// <summary>
    /// 从AndroidMainfest获取
    /// </summary>
    private string scAppId = "xxxxx";

    void Awake() {
        if (Instant != null) {
            DestroyImmediate(gameObject);
            //return;
        }

        ///统计分析初始化
        AppAnalyticsManager.Init(TalkingDataAPPID.games, scAppId);

        DontDestroyOnLoad(gameObject);
        Instant = this;
    }

    void Start() {
        //PlatformUISystem.Instant.SetPopupInfo("统计分析初始化成功");
    }

    void OnDestory() {
        ///统计分析结束
        AppAnalyticsManager.SessionStoped();
    }


}
