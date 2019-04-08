using UnityEngine;
using System.Collections;
using System;
using ShadowKit;

namespace ShadowKit.Action
{
	public class SpeechDevice{

		public static SpeechDevice _instance;
		public static SpeechDevice Instance {
			get {
				if (_instance == null) {
					_instance = new SpeechDevice ();
				}
				return _instance;
			}
		}

		public void init()
		{
			#if UNITY_ANDROID &&!UNITY_EDITOR
			AndroidConnection.Instance.addListener<SpeechListener> ("setSpeechEventCallback", new SpeechListener());
			#endif
		}

		public bool IsSpeechRunning()
		{
			#if UNITY_ANDROID &&!UNITY_EDITOR
			return AndroidConnection.Instance.Call<bool> ("unityIsSpeechRunning");
			#endif
			return false;
		}

		public void StartSpeech()
		{
			#if UNITY_ANDROID &&!UNITY_EDITOR
			if (!IsSpeechRunning ()) {
				AndroidConnection.Instance.Call ("unityStartSpeechService");
			}
			#endif
		}

		public void StopSpeech()
		{
			#if UNITY_ANDROID &&!UNITY_EDITOR
			if (IsSpeechRunning ()) {
				AndroidConnection.Instance.Call ("unityStopSpeechService");
			}
			#endif
		}
	}
}

