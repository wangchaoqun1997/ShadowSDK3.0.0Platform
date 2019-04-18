using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;




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
        DontDestroyOnLoad(gameObject);
        Instant = this;
    }

    void Start() {
        //WWWForm form = new WWWForm();
        //form.AddField("loginstr", "18918690343");
        //form.AddField("password", "wang89c51");
        //WebRequestBase wq = new WebRequestLogin(form);
        //WebRequestManager.Instant.AddWebRequest(wq);

        //LoginSystem.SetStrategy(new LoginStrategyAccountAndPasswordFrowWebRequest());
        //LoginSystem.Login();
        VerifyStatusSystem.Instant.SetVerifyStrategy(new VerifyStrategy1());
    }

    void Update() {
        VerifyStatusSystem.Instant.OnUpdate();
        

        //return;
        //if (SvrManager.Instance.status.running) {
        //    if ( (timeCount += Time.deltaTime) > platformTaskInterval) {
        //        timeCount = 0;
        //        Debug.Log(LOGTAG+"Do PlatformTasks");
        //        PlatformTasks();
        //    }
        //}
    }

    //void PlatformTasks() {

    //    if (AppInfo.isAPPLegal == false) {

    //        VerifyAPP.Start();

    //    }else if (AppInfo.isAPPLegal == true) {

    //        VerifySystemToken.Start();

    //        if (SysInfo.isTokenLegal == true) {

    //            VerifyAPPToken.Start();

    //        }

    //    }
    //}
    

    


}
