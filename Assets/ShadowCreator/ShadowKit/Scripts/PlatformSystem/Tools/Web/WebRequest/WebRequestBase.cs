using Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Logic.Scripts.Model;
using Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.UI.Scripts;
using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Tools.Web {
    public abstract class WebRequestBase {
        public string url;
        public WWWForm wwwForm;
        public WebRequestType webRequestType;
        private JsonData responseJsonData;

        /// <summary>
        /// log
        /// </summary>
        public string LOGTAG = "[WebRequestBase]:";

        public WebRequestBase(string _url, WWWForm _form=null) {
            url = _url;
            wwwForm = _form;

            if (SysInfo.systemToken != null) {
                wwwForm.AddField("token", SysInfo.systemToken);
            }
            if (AppInfo.APPID != null) {
                wwwForm.AddField("app_id", AppInfo.APPID);
            }
            
        }

        public virtual void SendCompleteCallBack(JsonData responseJson) { }
        public virtual void Success(JsonData responseJson) {
            Debug.Log(LOGTAG + "Sucess");
        }
        public virtual void Failed(JsonData responseJson) {
            Debug.Log(LOGTAG + "Failed");
        }
        public virtual void NetWorkError(string errText) {
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
                    responseJsonData = JsonMapper.ToObject(www.downloadHandler.text);
                    SendCompleteCallBack(responseJsonData);
                }

            } else if (webRequestType == WebRequestType.POST) {

                UnityWebRequest www = UnityWebRequest.Post(url, wwwForm);
                yield return www.SendWebRequest();
                if (www.isNetworkError || www.isHttpError) {
                    Debug.Log(www.error);
                    //responseJsonData = JsonMapper.ToObject(www.error);
                    NetWorkError(www.error);
                } else {
                    Debug.Log(www.downloadHandler.text);
                    responseJsonData = JsonMapper.ToObject(www.downloadHandler.text);
                    if ("200" == responseJsonData["code"].ToString()) {
                        Success(responseJsonData);
                    } else if ("-1" == responseJsonData["code"].ToString()) {
                        Failed(responseJsonData);
                    } else {
                        SendCompleteCallBack(responseJsonData);
                    }
                    
                }
            }
        }

    }

    public enum WebRequestType {
        GET,
        POST,
        PUT,
    }
}
