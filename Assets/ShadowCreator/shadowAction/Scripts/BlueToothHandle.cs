using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ShadowKit.Action
{
	public class BlueToothHandle : MonoBehaviour {
		private Vector3 resetEulerAngles = new Vector3 ();
        internal string blueToothHandleName;
        public DeviceId deviceId;
        public GameObject K02Model;
        public GameObject K07Model;
        public GameObject resetProcess;
		[SerializeField]
		private LineRenderer line = null;

        public enum DeviceId {
            ONE=0,
            TWO=1,
        }

        void OnEnable() {
            DisplayHandleModel();
        }
        
        void Start () {
            if (resetProcess != null) {
                resetProcess.SetActive(false);
            }
            BluetoothHandleDevice.Instance.enable3Dof (true);
			ActionInput.BluetoothHandleClickEvent += escapeClick;
            StartCoroutine (firstRest());
		}

		void LateUpdate () {
            Vector3 pos = ShadowSystem.Head.transform.position;
			pos.y -= 0.4f;
			this.transform.position = pos;

			this.transform.rotation = Quaternion.Euler (ActionInput.getBluetoothHandleAngles((int)deviceId) + resetEulerAngles);
			line.SetPosition (0, this.transform.position);
			line.SetPosition(1, SCInput.Instance.Position);
			line.enabled=true ;
        }

		void escapeClick(ActionKeyCode code,ActionKeyEvent type, int deviceId)
		{
            if (ActionInput.ActionKeys[ActionKeyCode.POWER] == ActionKeyEvent.DOWN) {
                if (resetProcess != null) {
                    resetProcess.SetActive(true);  
                }
            } else {
                if (resetProcess != null && resetProcess.activeSelf==true) {
                    resetProcess.SetActive(false);
                }
                if (ActionInput.ActionKeys[ActionKeyCode.POWER] == ActionKeyEvent.LONG) {
                    reset();
                }
            }
		}



        IEnumerator firstRest()
		{
			yield return new WaitForEndOfFrame ();
			reset();
		}

		void reset()
		{
			Vector3 angle = ShadowSystem.Head.transform.eulerAngles - ActionInput.getBluetoothHandleAngles ((int)deviceId);
			angle.x = 0;
			resetEulerAngles = angle;
		}

        void DisplayHandleModel() {
            if (!K02Model || !K07Model) {
                Debug.LogError("Please init K02Model and K07Model");
            }
            try {
                blueToothHandleName = AndroidConnection.Instance.Call<string>("getManufacturerModel", (int)deviceId);
            } catch(Exception e) {
                blueToothHandleName = "K07";
                Debug.Log("DisplayHandleModel:" + e);
            }
            Debug.Log("blueToothHandleName:" + blueToothHandleName);
            if (blueToothHandleName == "K07") {
                K02Model.SetActive(false);
                K07Model.SetActive(true);
            } else {
                K02Model.SetActive(true);
                K07Model.SetActive(false);
            }
        }

    }
}

