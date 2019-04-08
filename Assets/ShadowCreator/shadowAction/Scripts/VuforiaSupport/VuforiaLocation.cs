using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ShadowKit.Action.Vuforia
{
	public class VuforiaLocation : MonoBehaviour {

		// Use this for initialization
		void Start () {

		}

		// Update is called once per frame
		void Update () {
			gameObject.transform.position = SvrManager.Instance.modifyPosition;
			gameObject.transform.rotation = SvrManager.Instance.modifyOrientation;
		}
	}
}
