using UnityEngine;
using System.Collections;
using System;
using ShadowKit;

namespace ShadowKit.Action
{
	public class BluetoothHandleDevice{

		public static BluetoothHandleDevice _instance;
		public static BluetoothHandleDevice Instance {
			get {
				if (_instance == null) {
					_instance = new BluetoothHandleDevice ();
				}
				return _instance;
			}
		}
		private float escapeTime = -1;
		private bool _enable3Dof = false;
		private GameObject target;
		private int curDeviceId = -1;
//		private bool _enableAcc = false;

		private static readonly  Matrix4x4 FLIP_Z = Matrix4x4.Scale(new Vector3(1, 1, -1));
		private Matrix4x4 mPoseMatrix1;
		private Matrix4x4 mPoseMatrix2;
		public void init()
		{
			ShadowSystem.OnUpdateEvent += update;
			#if UNITY_ANDROID &&!UNITY_EDITOR
			AndroidConnection.Instance.addListener<HandShankConnStateListener> ("setHandShankConnStateCallback", new HandShankConnStateListener());
			AndroidConnection.Instance.addListener<HandShankKeyEventListener> ("setHandShankKeyEventCallback", new HandShankKeyEventListener (begin, end));
			onApplicationFocus(true);
			ShadowSystem.onApplicationFocusEvent += onApplicationFocus;
			#else
			ActionInput.unConnected(0);
			ActionInput.unConnected(1);
			#endif
		}

//		public void enableAcc(bool value)
//		{
//			_enableAcc = value;
//			if(!value)
//			{
//				AirInput.BluetoothHandleAcc = new Vector3 (0, 0, 0);
//			}
//		}

		public void enable3Dof(bool value)
		{
			_enable3Dof = value;
			if(!value)
			{
				ActionInput.setBluetoothHandleRotation (new Quaternion (), 0);
				ActionInput.setBluetoothHandleRotation (new Quaternion (), 1);
			}
		}

		/// <summary>
		/// 唤醒代码
		/// </summary>
		/// <param name="hasFocus">If set to <c>true</c> has focus.</param>
		void onApplicationFocus(bool hasFocus)
		{
			if (hasFocus) {
				int BluetoothConnect = AndroidConnection.Instance.Call<int> ("unityBTConnected",0);
				if (BluetoothConnect == 0) {
					ActionInput.unConnected (0);
				} else {
					ActionInput.connected (0);
				}

				BluetoothConnect = AndroidConnection.Instance.Call<int> ("unityBTConnected",1);
				if (BluetoothConnect == 0) {
					ActionInput.unConnected (1);
				} else {
					ActionInput.connected (1);
				}
			}
		}
			
		void update()
		{
			#if UNITY_ANDROID &&!UNITY_EDITOR
			drag ();
			update3Dof ();
			updateEscape ();
			updateTouchPosition ();
			#endif
		}

		void begin(int deviceId)
		{
			if (SCInput.Instance.target != null && target == null && curDeviceId == -1) {
				target = SCInput.Instance.target;
				SCInput.Instance.PointDown (target);
			}
		}

		void drag()
		{
			if (target == null) {
				return;
			}
			SCInput.Instance.Drag (target);
		}

		void end(int deviceId)
		{
			if (deviceId != curDeviceId) {
				return;
			}
			SCInput.Instance.PointUp (target);
			target = null;
			deviceId = -1;
		}

		void updateEscape()
		{
			if (Input.GetKeyDown(KeyCode.Escape)) {
				escapeTime = Time.time;
			}

			if (Input.GetKeyUp (KeyCode.Escape)) {
				if (escapeTime > 0 && Time.time - escapeTime < 1) {
					if (!ActionInput.escapeDown ()) {
						ShadowSystem.Quit ();
					}
				}
				escapeTime = -1;
			}
		}

		void updateTouchPosition()
		{
            int[] pos = new int[] { 0,0};
            try {
                if (ActionInput.IsBluetoothHandleConnected(0)) {
                pos = AndroidConnection.Instance.Call<int[]>("unityGetTouchPosition", 0);
                }
            } catch {
                pos[0] = 0;
                pos[1] = 0;
            }
            if (pos[0] == 0 && pos[1] == 0) {
                ActionInput.DeviceTouchPosition[0] = Vector2.zero;
                ActionInput.onTouchEnd(0);
            } else {
                if (ActionInput.DeviceTouchPosition[0] == Vector2.zero) {
                    ActionInput.onTouchBegin(0);
                }
                ActionInput.DeviceTouchPosition[0] = new Vector2(pos[0], pos[1]);
            }



            try {
				if (ActionInput.IsBluetoothHandleConnected(1)){
                pos = AndroidConnection.Instance.Call<int[]>("unityGetTouchPosition", 1);
                }
            } catch {
                pos[0] = 0;
                pos[1] = 0;
            }
            if (pos[0] == 0 && pos[1] == 0) {
                ActionInput.DeviceTouchPosition[1] = Vector2.zero;
                ActionInput.onTouchEnd(1);
            } else {
                if (ActionInput.DeviceTouchPosition[1] == Vector2.zero) {
                    ActionInput.onTouchBegin(1);
                }
                ActionInput.DeviceTouchPosition[1] = new Vector2(pos[0], pos[1]);
            }
        }

        void update3Dof()
		{
			if (_enable3Dof) {
				if (ActionInput.IsBluetoothHandleConnected (0)) {
					float[] array = AndroidConnection.Instance.Call<float[]> ("unity3DofMatrix", 0);
					if (array == null) {
						return;
					} else {
						for (int index = 0; index < 16; index++) {
							mPoseMatrix1 [index] = array [index];
						}

						mPoseMatrix1 = FLIP_Z * mPoseMatrix1.inverse * FLIP_Z;
						Quaternion rotation =  Quaternion.LookRotation (mPoseMatrix1.GetColumn (2), mPoseMatrix1.GetColumn (1));
						ActionInput.setBluetoothHandleRotation (rotation, 0);
					}
				}

				if (ActionInput.IsBluetoothHandleConnected (1)) {
					float[] array1 = AndroidConnection.Instance.Call<float[]> ("unity3DofMatrix", 1);
					if (array1 == null) {
						return;
					} else {
						for (int index = 0; index < 16; index++) {
							mPoseMatrix2 [index] = array1 [index];
						}

						mPoseMatrix2 = FLIP_Z * mPoseMatrix2.inverse * FLIP_Z;
						Quaternion rotation =  Quaternion.LookRotation (mPoseMatrix2.GetColumn (2), mPoseMatrix2.GetColumn (1));
						ActionInput.setBluetoothHandleRotation (rotation, 1);
					}
				}
			}
		}

	}
}

