using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ShadowKit.Action
{
	public class GestureEventListener : AndroidJavaProxy {

		bool haveHand = false;
		bool isChange = false;
		public GestureEventListener():base("com.invision.unity.callback.GestureEventCallback")
		{
			ShadowSystem.OnUpdateEvent += Update;
		}

		void onGestureStatusChanged(bool haveHand , int handShape, int handGesture)
		{
			this.haveHand = haveHand;
			isChange = true;
		}

		void Update()
		{
			if (isChange) {
				isChange = false;
				ActionInput.onGestureChange (haveHand);
			}
		}
	}
}
