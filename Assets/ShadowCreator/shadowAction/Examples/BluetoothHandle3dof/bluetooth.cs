using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ShadowKit.Action;
namespace ShadowKit.Air.Example
{
	public class bluetooth : MonoBehaviour {
		public int deviceId;
		public TextMesh stateText;

		// Use this for initialization
		void Start () {
			BluetoothHandleDevice.Instance.enable3Dof (true);
		}

		// Update is called once per frame
		void LateUpdate () {
			this.transform.rotation = ActionInput.getBluetoothHandleRotation (deviceId);
			bool isConnect = ActionInput.IsBluetoothHandleConnected(deviceId);
			if (isConnect) {
				stateText.text = "已连接";
			} else {
				stateText.text = "未连接";
			}
		}
	}
}

