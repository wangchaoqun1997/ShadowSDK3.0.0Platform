using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;




public class PlatformSystem : MonoBehaviour {
    
    public static PlatformSystem Instant;

    void Awake() {
        if (Instant != null) {
            DestroyImmediate(gameObject);
            //return;
        }
        DontDestroyOnLoad(gameObject);
        Instant = this;
    }

    void Start() {
        DebugMy.Log("Start",this);

        //UserSystem.Instant.SysInfo.ResetUserInfo();
        //RegisterSystem.SetStrategy(new RegisterStrategyPhoneFromWebRequest());
        //RegisterSystem.Register();
    }

    void Update() {
        VerifyStatusSystem.Instant.OnUpdate();
    }

}
