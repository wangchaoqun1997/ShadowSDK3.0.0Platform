//using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using System;
using ShadowKit.UI;


namespace ShadowKit
{
	public class ShadowSystem : MonoBehaviour{
		[Serializable]
		public class ShadowSetting{
			public AudioClip defaultClickAudio;
		}
		[SerializeField]
		public ShadowSetting setting;
		public delegate void OnUpdate(); 
		public static  OnUpdate OnUpdateEvent;//代理方法 update调用 给非组件的脚本使用

		public delegate void onApplicationFocus(bool hasFocus);
		public static event onApplicationFocus onApplicationFocusEvent;//代理方法 当程序获得或失去焦点时调用

		public static GameObject Head;//头部组件
		public static Camera Camera;//摄像机
		public static System.Action Quit;//程序退出方法 由各个设备sdk注册  使用时调用ShadowSystem.Quit();

		private static bool init;
	
		void Awake()
		{
			if (!init) {
				DontDestroyOnLoad(this.gameObject);
				MouseDevice.Instance.init ();
				if (setting.defaultClickAudio != null) {
					SCButton.DefaultClickAudio = setting.defaultClickAudio;
				}
				init = true;
			} else {
				Destroy (this.gameObject);
				return;
			}
		}

		void Start()
		{
			Screen.sleepTimeout = SleepTimeout.NeverSleep;
			Input.backButtonLeavesApp = false;
		}

		// Update is called once per frame
		void LateUpdate() {
			if (OnUpdateEvent != null) {
				OnUpdateEvent ();
			}
		}

		void OnApplicationFocus(bool hasFocus)
		{
			if (onApplicationFocusEvent != null) {
				onApplicationFocusEvent (hasFocus);
			}
		}
	}
}

