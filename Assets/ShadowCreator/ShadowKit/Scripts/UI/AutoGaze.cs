using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ShadowKit.UI
{
	public class AutoGaze : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler{

		public static bool StartAutoGaze = false;
		public static bool EndAutoGaze = false;
		public static float AutoGazeTime = 1;
		[SerializeField]
		private float autoClickTime = 0;//是否需要长注视
		private float curDelayTime;//当前执行时间
		private bool  inAutoClick;//是否正在进行凝视

		// Update is called once per frame
		void Update () {
			autoClick ();
		}

		private void autoClick()
		{
			if (autoClickTime > 0  &&  inAutoClick) {
				curDelayTime = curDelayTime - Time.deltaTime;
				curDelayTime = curDelayTime < 0 ? 0 : curDelayTime;
				if (curDelayTime <= 0) {
					if (SCInput.Instance.target == gameObject) {
						SCInput.Instance.PointDown (gameObject);
					}
					StartAutoGaze = false;
					EndAutoGaze = true;
					inAutoClick = false;
					curDelayTime = autoClickTime;
				}
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (autoClickTime > 0) {
				StartAutoGaze = true;
				EndAutoGaze = false;
				AutoGazeTime = autoClickTime;
				inAutoClick = true;
				curDelayTime = autoClickTime;
			}
		}

		public virtual void OnPointerExit (PointerEventData eventData)
		{
			if (autoClickTime > 0) {
				StartAutoGaze = false;
				EndAutoGaze = true;
				inAutoClick = false;
				curDelayTime = autoClickTime;
			}
		}
	}
}

