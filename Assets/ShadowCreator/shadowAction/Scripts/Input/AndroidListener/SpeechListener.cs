using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ShadowKit.Action
{
	public class SpeechListener : AndroidJavaProxy {

		bool isChange = false;
		string msg;
		public SpeechListener():base("com.invision.unity.callback.SpeechEventCallback")
		{
			ShadowSystem.OnUpdateEvent += Update;

		}

		void Update()
		{
			if (isChange) {
				isChange = false;
				ActionInput.onSpeechAwake (msg);
			}
		}

		/**
     * 语音服务启动完成
     */
		void onStartCompleted()
		{
		}

		/**
     * 语音服务退出
     */
		void onExit()
		{
		}
			
		/**
     * 上报给SDK的唤醒词:off go
     * @param msg
     */
		void onWake(string msg)
		{
			isChange = true;
			this.msg = msg;
		}

		/**
     * 识别结果：目前没用
     * @param msg
     */
		void onRecog(String msg)
		{
		}
	}
}
