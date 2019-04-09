using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ShadowKit
{
	public class InputSystem : MonoBehaviour {

		public static GameObject Gazer;//凝视的物体，从这个物体发出射线 默认是ShadowSystem.Head
		[SerializeField]
		private float MaxRaycastDistance = 20.0f;//射线最远距离
		[SerializeField]
		private LayerMask RaycastLayerMask = Physics.DefaultRaycastLayers;//凝视layer列表
		[SerializeField]
		private bool useNormal = false;

        private Vector3 gazeOrigin;
        private Vector3 gazeDirection;
        private RaycastHit hitinfo;
        private Vector3 pos;
        private  GameObject newObj;
        void Start () {
		}

		void LateUpdate () {
			updateGaze ();

		}

		void updateGaze()
		{
			if (Gazer == null) {
				Gazer = ShadowSystem.Head;
			}
			gazeOrigin = Gazer.transform.position;
			gazeDirection = Gazer.transform.forward;
			if (Physics.Raycast (gazeOrigin, gazeDirection, out hitinfo, MaxRaycastDistance, RaycastLayerMask)) {//从摄像机发出到点击坐标的射线
				pos = hitinfo.point;
				SCInput.Instance.Position = pos;
				SCInput.Instance.Distance = hitinfo.distance;
				if (useNormal) {
					SCInput.Instance.Normal = hitinfo.normal;
				} else {
					SCInput.Instance.Normal = gazeDirection;
				}
			     newObj = hitinfo.collider.gameObject;
				if (newObj != SCInput.Instance.target) {
					if (SCInput.Instance.target != null) {
						SCInput.Instance.PointerExit (SCInput.Instance.target);
					}
					SCInput.Instance.PointerEnter (newObj);
					SCInput.Instance.SetTarget (newObj);
				}
			} else {
				if (SCInput.Instance.target != null) {
					SCInput.Instance.PointerExit (SCInput.Instance.target);
				}
				SCInput.Instance.SetTarget(null);
				SCInput.Instance.Position = gazeOrigin + (gazeDirection * 2.0f);
				SCInput.Instance.Distance = 2;
				SCInput.Instance.Normal = gazeDirection;
			}
		}
	}
}

