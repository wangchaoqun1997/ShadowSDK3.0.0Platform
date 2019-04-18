

using LitJson;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public abstract class WebRequestBase {
    public string url;
    public WWWForm wwwForm;
    public WebRequestType webRequestType;
    private JsonData responseJsonData;

    protected Action<JsonData> mSuccess;
    protected Action<JsonData> mFailed;



    public enum WebRequestType {
        GET,
        POST,
        PUT,
    }

    public string LOGTAG = "[WebRequestBase]:";

    public WebRequestBase(string _url, WWWForm _form, Action<JsonData> success, Action<JsonData> failed) {
        url = _url;
        wwwForm = _form;
        mSuccess = success;
        mFailed = failed;
    }

    //public abstract void Success(JsonData responseJson);
    //public abstract void Failed(JsonData responseJson);

    public void NetWorkError(string errText) {
        Debug.Log(LOGTAG + "NetWorkError");
        PlatformUISystem.Instant.uiPanelsManager.PushUIPanel(UIPanelsType.InfoType1Panel, "ERROR: NetWorkError,Please Open Wifi");
    }


    public virtual IEnumerator SendRequest() {

        if (webRequestType == WebRequestType.GET) {
            UnityWebRequest www = UnityWebRequest.Get(url);
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError) {
                Debug.Log(www.error);
                //responseJsonData = JsonMapper.ToObject(www.error);
                NetWorkError(www.error);
            } else {
                Debug.Log(www.downloadHandler.text);
                responseJsonData = JsonMapper.ToObject(www.downloadHandler.text);
                if (mSuccess != null) {
                    mSuccess(responseJsonData);
                }

            }

        } else if (webRequestType == WebRequestType.POST) {

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
                try {
                    responseJsonData = JsonMapper.ToObject(www.downloadHandler.text);
                    if ("200" == responseJsonData["code"].ToString()) {
                        if (mSuccess != null) {
                            mSuccess(responseJsonData);
                        }
                    } else if ("-1" == responseJsonData["code"].ToString()) {
                        if (mFailed != null) {
                            mFailed(responseJsonData);
                        }
                    }
                } catch (Exception e) {
                    Debug.Log(e);
                    
                }
                

            }
        }
    }

}

