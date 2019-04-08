using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using ShadowKit.Action;
using UnityEngine.UI;
using ShadowKit.UI;


namespace ShadowKit{
	public class SCFocus : MonoBehaviour {

		[SerializeField]
		private Animator _gazeLoading = null;

		[SerializeField]
		private GameObject _gesturePoint = null;
		[SerializeField]
		private GameObject _clickPoint = null;
		[SerializeField]
		private GameObject _item = null;
		private bool hasGesture = false;

		void Awake () {
			ActionInput.GestureLoseEvent += onGestureLose;
			ActionInput.GestureFindEvent += onGestureFind;
			SCInput.AnyKeyDownEvent += onClick;
			_gazeLoading.enabled = false;
			_gazeLoading.gameObject.SetActive (false);
		}

		// Update is called once per frame
		void LateUpdate () {
			if (SCInput.Instance != null) {
				transform.localPosition = new Vector3 (0, 0, SCInput.Instance.Distance);
				_item.transform.rotation = Quaternion.FromToRotation (Vector3.forward, SCInput.Instance.Normal); 			
			}
			if (AutoGaze.StartAutoGaze) {
				_gazeLoading.gameObject.SetActive (true);
				_gazeLoading.enabled = true;
				_gazeLoading.SetFloat ("speedChange", 1.0f/AutoGaze.AutoGazeTime);
				_gazeLoading.Play (_gazeLoading.GetCurrentAnimatorClipInfo (0) [0].clip.name, -1, 0);
				_gazeLoading.Update (0);
				AutoGaze.StartAutoGaze = false;
			}
			if (AutoGaze.EndAutoGaze) {
				_gazeLoading.enabled = false;
				_gazeLoading.gameObject.SetActive (false);
			}
		}
        void OnDestroy() {
            ActionInput.GestureLoseEvent -= onGestureLose;
            ActionInput.GestureFindEvent -= onGestureFind;
            SCInput.AnyKeyDownEvent -= onClick;
        }

        private void onClick()
		{
			if (hasGesture) {
				_gesturePoint.transform.DOScale (new Vector3 (0.5f, 0.5f, 1), 0.1f).OnComplete (gesturePointBack).SetAutoKill (true);
			} else {
				showClickPoint ();
			}
		}

		private void gesturePointBack()
		{
			_gesturePoint.transform.DOScale (1, 0.1f).SetAutoKill (true);
		}

		private void showClickPoint()
		{
			_clickPoint.SetActive (true);
			_clickPoint.transform.localScale = new Vector3 (0, 0, 1);
			_clickPoint.transform.DOScale (1, 0.15f).OnComplete (clickPointBack).SetAutoKill (true);
		}

		private void clickPointBack()
		{
			_clickPoint.transform.DOScale (new Vector3 (0, 0, 1), 0.15f).OnComplete (hideClickPoint).SetAutoKill (true);
		}

		private void hideClickPoint()
		{
			_clickPoint.SetActive (false);
		}

		void onGestureLose()
		{
			_gesturePoint.SetActive (false);
			hasGesture = false;
		}

		void onGestureFind()
		{
			_gesturePoint.SetActive (true);
			hasGesture = true;
		}

	}
}

