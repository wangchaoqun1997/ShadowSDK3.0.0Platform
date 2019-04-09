using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.Tools.Web {
    public class WebRequestManager : MonoBehaviour {

        List<WebRequestBase> webRequestList = new List<WebRequestBase>();

        public static WebRequestManager Instant;
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
            //Debug.Log("SendRequest START :" + webRequestList.Count);
            WebRequestBase webRequest = webRequestList[0];
            webRequestList.RemoveAt(0);
            yield return StartCoroutine(webRequest.SendRequest());
            //Debug.Log("SendRequest END :" + webRequestList.Count);
            CheckQueue();
            
        }

    }
}
