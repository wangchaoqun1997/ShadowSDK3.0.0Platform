using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ShadowKit.Action
{
	public class HandShankKeyEventListener : AndroidJavaProxy {

		class ShankKeyCode{
			public int keycode = -1;
			public int keyevent = -1;
			public int deviceId = -1;
		}

		Action<int> begin;
		Action<int> end;
		List<ShankKeyCode> keyList = new List<ShankKeyCode>();
		public HandShankKeyEventListener(Action<int> begin,Action<int> end):base("com.invision.unity.callback.HandShankKeyEventCallback")
		{
			this.begin = begin;
			this.end = end;
			ShadowSystem.OnUpdateEvent += Update;
		}

		/**
     * 手势启动
     */
		void onStartCompleted()
		{
		}

		/**
     * 手势退出
     */
		void onExit()
		{
		}

        void Update() {
            DispatchKey();
        }

        //wangcq327 20181221
        //备注：此接口android有按键事件时触发，不是每次触发都有机会在Update中被派发，所以需要用keyList保存起来
        //此接口中也不能直接派发事件，原因是派发事件的方法中有委托
        void onKeyEventChanged(int keycode, int keyevent, int deviceId)
		{
            keyList.Add(new ShankKeyCode (){ keycode = keycode, keyevent = keyevent, deviceId = deviceId });
        }

        void DispatchKey() {
            if (keyList.Count != 0) {
                ActionInput.controllerClick(keyList[0].keycode, keyList[0].keyevent, keyList[0].deviceId);
                keyList.RemoveAt(0);
            }
        }
    }
}
