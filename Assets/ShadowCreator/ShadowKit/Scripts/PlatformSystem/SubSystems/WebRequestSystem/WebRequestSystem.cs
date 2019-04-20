using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class WebRequestSystem : MonoBehaviour {

    List<WebRequestBase> webRequestList = new List<WebRequestBase>();

    public static WebRequestSystem Instant;
    void Awake() {
        if (Instant != null) {
            DestroyImmediate(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        Instant = this;
    }


    public void AddWebRequest(WebRequestBase webRequest) {
        webRequestList.Add(webRequest);
        CheckQueue();
    }

    private void CheckQueue() {
        if (webRequestList.Count == 0) {
            return;
        }
        StartCoroutine(SendRequest());
    }

    private IEnumerator SendRequest() {
        WebRequestBase webRequest = webRequestList[0];
        webRequestList.RemoveAt(0);
        yield return StartCoroutine(webRequest.SendRequest());
        CheckQueue();

    }


    public void GetSessionId(Action<JsonData> GetSessionIDSuccess, Action<JsonData> GetSessionIDFailed) {
        WebRequestBase wq = new WebRequestGetSessionID(new WWWForm(), GetSessionIDSuccess, GetSessionIDFailed);
        WebRequestSystem.Instant.AddWebRequest(wq);
    }

    public void GetVerificationCode(Action<byte[]> GetVerificationCodeSuccess) {
        WWWForm form = new WWWForm();
        form.AddField("session_id", UserSystem.Instant.SysInfo.SessionId);
        WebRequestBase wq = new WebRequestGetVerificationCode(form, GetVerificationCodeSuccess);
        WebRequestSystem.Instant.AddWebRequest(wq);
    }

    public void Login(Action<JsonData> LoginSuccess, Action<JsonData> LoginFailed,WWWForm form) {
        WebRequestBase wq = new WebRequestLogin(form, LoginSuccess, LoginFailed);
        WebRequestSystem.Instant.AddWebRequest(wq);
    }

    public void VerifyAPPID(Action<JsonData> VerifyAPPIDSuccess, Action<JsonData> VerifyAPPIDFailed) {
        WebRequestBase wq = new WebRequestVerifyAPPID(new WWWForm(),VerifyAPPIDSuccess, VerifyAPPIDFailed);
        WebRequestSystem.Instant.AddWebRequest(wq);
    }

    public void GetAppToken(Action<JsonData> GetAppTokenSuccess, Action<JsonData> GetAppTokenFailed) {
        WebRequestBase wq = new WebRequestGetAppToken(new WWWForm(), GetAppTokenSuccess, GetAppTokenFailed);
        WebRequestSystem.Instant.AddWebRequest(wq);
    }

    public void GetSystemToken(Action<JsonData> GetSystemTokenSuccess, Action<JsonData> GetSystemTokenFailed) {
        WebRequestBase wq = new WebRequestGetSystemToken(new WWWForm(), GetSystemTokenSuccess, GetSystemTokenFailed);
        WebRequestSystem.Instant.AddWebRequest(wq);
    }


    public void GetRegisterPhoneVerificationcode(Action<JsonData> GetSystemTokenSuccess, Action<JsonData> GetSystemTokenFailed, WWWForm form) {
        WebRequestBase wq = new WebRequestGetRegisterPhoneVerificationcode(form, GetSystemTokenSuccess, GetSystemTokenFailed);
        WebRequestSystem.Instant.AddWebRequest(wq);
    }


    public void Register(Action<JsonData> GetSystemTokenSuccess, Action<JsonData> GetSystemTokenFailed) {
        WebRequestBase wq = new WebRequestRegister(new WWWForm(), GetSystemTokenSuccess, GetSystemTokenFailed);
        WebRequestSystem.Instant.AddWebRequest(wq);
    }


}
