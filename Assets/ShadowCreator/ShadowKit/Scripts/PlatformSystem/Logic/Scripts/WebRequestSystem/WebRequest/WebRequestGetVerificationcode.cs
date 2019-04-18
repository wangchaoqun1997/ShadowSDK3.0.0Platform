using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class WebRequestGetVerificationCode : WebRequestBase {

    protected Action<byte[]> webRequestSuccess;

    public WebRequestGetVerificationCode(WWWForm form, Action<byte[]> success) : base(WebRequestURL.GetVerificationCode, form, null,null) {
        webRequestType = WebRequestType.POST;
        webRequestSuccess = success;
        LOGTAG = "[WebRequestGetAppToken]:";
    }


    public override IEnumerator SendRequest() {
        if (SysInfo.SystemToken != null) {
            wwwForm.AddField("token", SysInfo.SystemToken);
        }
        if (AppInfo.APPID != null) {
            wwwForm.AddField("app_id", AppInfo.APPID);
        }

        UnityWebRequest www = UnityWebRequest.Post(url, wwwForm);
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
            //responseJsonData = JsonMapper.ToObject(www.error);
            NetWorkError(www.error);
        } else {
            Debug.Log(www.downloadHandler.text);
            
            //byte[] byteArray = System.Text.Encoding.UTF32.GetBytes(www.downloadHandler.text);
            
            if (webRequestSuccess != null) {
                webRequestSuccess(www.downloadHandler.data);
            }

        }
    }
}