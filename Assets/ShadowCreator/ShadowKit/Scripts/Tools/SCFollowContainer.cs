using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


namespace ShadowKit
{
	public class SCFollowContainer : MonoBehaviour 
	{
		void Start ()
		{
			transform.position = ShadowSystem.Head.transform.position;
			Vector3 angle = ShadowSystem.Head.transform.eulerAngles;

			transform.rotation = Quaternion.Euler (0, angle.y, 0);
		}

		public void Reset()
		{
			
			transform.DOMove (ShadowSystem.Head.transform.position, 0.5f).SetEase (Ease.Linear).SetAutoKill (true);
			Vector3 angle = ShadowSystem.Head.transform.eulerAngles;
			transform.DORotate (new Vector3 (0, angle.y, 0), 0.5f).SetEase (Ease.Linear).SetAutoKill (true);
		}

		public static SCFollowContainer Create()
		{
			GameObject	container = (GameObject)Instantiate (Resources.Load ("Prefabs/FollowContainer"));
			container.name = "FollowContainer";
			return container.GetComponent<SCFollowContainer> ();
		}
	}
}

