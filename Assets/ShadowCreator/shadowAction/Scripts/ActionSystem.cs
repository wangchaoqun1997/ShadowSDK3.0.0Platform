using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace ShadowKit.Action
{
	public class ActionSystem : MonoBehaviour {
		public static ActionSystem Instance;
		[SerializeField]
		private GameObject Head;
		[SerializeField]
		private GameObject BluetoothHandle;
		[SerializeField]
		private Camera Camera;
		[SerializeField]
		private GameObject Focus;
		[SerializeField]
		private bool useBluetoothGaze = true;
		public bool UseBluetoothGaze {		//开启或关闭蓝牙手柄射线对焦
			get{ return useBluetoothGaze; }
			set {
				useBluetoothGaze = value;
				if (value && ActionInput.IsBluetoothHandleConnected (0)) {
					BlueToothHandleConnected ();
				} else {
					BlueToothHandleUnConnected ();
				}
			}
		}

	
		private static bool init;
		private SvrManager svrManager = null;
		private int sceneIndex = 0;

		void Awake()
		{
			if (!init) {
				Instance = this;
				DontDestroyOnLoad (this.gameObject);
				init = true;
				ShadowSystem.Head = Head;
				ShadowSystem.Camera = Camera;
				UseBluetoothGaze  = useBluetoothGaze;
				try {
					BluetoothHandleDevice.Instance.init ();
					//GestureDevice.Instance.init();
					//SpeechDevice.Instance.init();
				} catch {
					Debug.Log ("组建初始化失败");
				}
			} else {
				Destroy (this.gameObject);
				return;
			}
		}
			
		void Start()
		{
			svrManager = SvrManager.Instance;
			ShadowSystem.Quit = doQuit;
//			ShadowSystem.ReLocate = ReLocate;
//			ShadowSystem.Reset = Reset;
			Input.backButtonLeavesApp = false;

			var activeScene = SceneManager.GetActiveScene();
			sceneIndex = activeScene.buildIndex;
		}

		/// <summary>
		/// 重置环境
		/// </summary>
		public void Reset()
		{
			StartCoroutine (doReset());
		}

		/// <summary>
		/// 重置场景坐标
		/// </summary>
		public void ReLocate()
		{
			SvrPlugin.Instance.RecenterTracking();
		}

		private void doQuit()
		{
			StartCoroutine (quit());
		}
			
		IEnumerator doReset()
		{
//			svrManager.SetOverlayFade (SvrManager.eFadeState.FadeOut);
//			yield return new WaitUntil (() => svrManager.IsOverlayFading () == false);

			svrManager.Shutdown ();
			yield return new WaitUntil (() => svrManager.Initialized == false);
			SceneManager.LoadScene (sceneIndex);
			System.GC.Collect ();
		}


		IEnumerator changeScene()
		{
//			svrManager.SetOverlayFade(SvrManager.eFadeState.FadeOut);
//			yield return new WaitUntil(() => svrManager.IsOverlayFading() == false);

			// Load next scene in build settings, quit when done
			svrManager.Shutdown();
			yield return new WaitUntil(() => svrManager.Initialized == false);
			sceneIndex=sceneIndex+1;
			sceneIndex = sceneIndex > 2 ? 0 : sceneIndex;
			//_senceIndexText.text = "新加载"+sceneIndex.ToString ();
			SceneManager.LoadScene(sceneIndex);

			System.GC.Collect();
		}

		IEnumerator quit()
		{
			svrManager.Shutdown();
			yield return new WaitUntil(() => svrManager.Initialized == false);

			SceneManager.LoadScene(0);

			System.GC.Collect();
			sceneIndex = -1;
			Application.Quit();
		}


		public void BlueToothHandleConnected()
		{
			if (useBluetoothGaze) {
				InputSystem.Gazer = BluetoothHandle;
				BluetoothHandle.SetActive (true);
				if (Focus) {
					Focus.SetActive (false);
				}
			}
		}
			
		public void BlueToothHandleUnConnected()
		{
			InputSystem.Gazer = null;
			BluetoothHandle.SetActive (false);
			if (Focus) {
				Focus.SetActive (true);
			}
		}
	}
}

