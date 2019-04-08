using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using ShadowKit.Action;


namespace ShadowKit{
	public class SCFocusLight : MonoBehaviour {

		[SerializeField]
		private GameObject _light = null;
		// Use this for initialization
		void Start () {
		}

		// Update is called once per frame
		void LateUpdate () {
			if (SCInput.Instance == null) {
				_light.SetActive (false);
				return;
			}
			_light.SetActive (true);
			transform.position = SCInput.Instance.Position;
//			Vector3 posInHead = transform.InverseTransformPoint (SCInput.Instance.Position);
//			_light.transform.localPosition = new Vector3 (posInHead.x, posInHead.y, _light.transform.localPosition.z);
			transform.rotation = Quaternion.FromToRotation (Vector3.back, SCInput.Instance.Normal); 
		}
	}
}

