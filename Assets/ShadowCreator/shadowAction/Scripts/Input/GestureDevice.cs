using UnityEngine;
using System.Collections;
using System;
using ShadowKit;

namespace ShadowKit.Action
{
	public class GestureDevice{

		public static GestureDevice _instance;
		public static GestureDevice Instance {
			get {
				if (_instance == null) {
					_instance = new GestureDevice ();
				}
				return _instance;
			}
		}

		public void init()
		{
			#if UNITY_ANDROID &&!UNITY_EDITOR
			Debug.Log("wjh.setGestureEventCallback.begin");
			AndroidConnection.Instance.addListener<GestureEventListener> ("setGestureEventCallback", new GestureEventListener());
			#endif
		}

		public bool IsGestureRunning()
		{
			#if UNITY_ANDROID &&!UNITY_EDITOR
			return AndroidConnection.Instance.Call <bool>("unityIsGestureRunning");
			#endif
			return false;
		}

		public void StartGesture()
		{
			#if UNITY_ANDROID &&!UNITY_EDITOR
			if (!IsGestureRunning ()) {
			AndroidConnection.Instance.Call ("unityStartGestureService");
			}
			#endif
		}

		public void StopGesture()
		{
			#if UNITY_ANDROID &&!UNITY_EDITOR
			if (IsGestureRunning ()) {
			AndroidConnection.Instance.Call ("unityStopGestureService");
			}
			#endif
		}
	}

}

