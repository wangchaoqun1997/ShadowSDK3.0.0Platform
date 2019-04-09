using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ShadowKit;
using UnityEngine.UI;
using Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Login;
using Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Register;
using Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Tools.Web;
using UnityEngine.Networking;
using Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Tools.VerifySystemToken;
using Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Logic.Scripts.Login;
using Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Logic.Scripts.VerifyStatus;
using Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.UI.Scripts;
using Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Logic.Scripts.Model;

public class PlatformLogicSystem : MonoBehaviour {

    public const string LOGTAG = "[PlatformSystem]:";

    public static PlatformLogicSystem Instant;
    
    /// <summary>
    /// 从AndroidMainfest获取
    /// </summary>
    private string scAppId = "xxxxx";

    private static float platformTaskInterval = 5;

    private float timeCount = platformTaskInterval;


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
        
        //WWWForm form = new WWWForm();
        //form.AddField("loginstr", "18918690343");
        //form.AddField("password", "wang89c51");
        //WebRequestBase wq = new WebRequestLogin(form);
        //WebRequestManager.Instant.AddWebRequest(wq);
    }

    void Update() {
        if (SvrManager.Instance.status.running) {
            if ( (timeCount += Time.deltaTime) > platformTaskInterval) {
                timeCount = 0;
                Debug.Log(LOGTAG+"Do PlatformTasks");
                PlatformTasks();
            }
        }
    }

    void PlatformTasks() {

        if (AppInfo.isAPPLegal == false) {

            VerifyAPP.Start();

        }else if (AppInfo.isAPPLegal == true) {

            VerifySystemToken.Start();

            if (SysInfo.isTokenLegal == true) {

                VerifyAPPToken.Start();

            }

        }
    }
    



    void OnDestory() {
        ///统计分析结束
        AppAnalyticsManager.SessionStoped();
    }


}
