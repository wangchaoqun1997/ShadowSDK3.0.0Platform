using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShadowKit
{
	public class SCLensFollow : MonoBehaviour {

		[SerializeField]
		private float followDistance = 2;
		[SerializeField]
		private float followTime = 2;
		[SerializeField]
		private float followAngle = 60;

		private SCFollowContainer container;
		private bool inReset = false;

		void Start ()
		{
			container = SCFollowContainer.Create ();
			transform.parent = container.transform;
			inReset = false;
		}

		void Update()  
		{  
			if (IsInView(transform.position))     
			{  
				if (inReset) {
					StopCoroutine ("reset");
					inReset = false;
					Debug.Log("目前本物体在摄像机范围内"); 
				}
			}  
			else
			{  
				if (!inReset) {
					StartCoroutine ("reset");
					inReset = true;
					Debug.Log("目前本物体不在摄像机范围内");  
				}
			} 
		}

		void OnDestroy()
		{
			Destroy (container.gameObject);
		}

		IEnumerator reset()
		{
			inReset = true;
			while (true) {
				yield return new WaitForSeconds (followTime);
				container.Reset ();
			}
		}

		bool IsInView(Vector3 worldPos)
		{  
			Camera cam = ShadowSystem.Camera;
			Vector3 pos = container.transform.forward * followDistance;
			pos.y = cam.transform.position.normalized.y;
			bool  f = Vector3.Angle((pos - cam.transform.position).normalized, cam.transform.forward.normalized) < followAngle;
			return f;
		}
	}
}

