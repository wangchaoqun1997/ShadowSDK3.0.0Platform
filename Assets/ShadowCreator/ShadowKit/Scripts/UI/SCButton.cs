using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using DG.Tweening;


namespace ShadowKit.UI{
	[RequireComponent(typeof(BoxCollider))]
	[AddComponentMenu("ShadowCreator/SCButton")]
	public class SCButton :MonoBehaviour,  IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IEventSystemHandler,IDragHandler, IPointerEnterHandler, IPointerExitHandler{
		public enum Transition
		{
			None,
			Scale,
			Position,
		}
			
		public static AudioClip DefaultClickAudio;
		public Transition transition = Transition.None;
		public float scalNum = 1.1f;
		public float transitionTime = 0.2f;
		public float forwardNum = 0.05f;


		public UnityEvent onClick;

		private Vector3 initScal;
		private Vector3 initPosition;
		private Quaternion initRotation;

		private AudioSource _audioSource;
		private bool _needClickAudio = false;
		void Awake()
		{
			initScal= transform.localScale;
		}

		void  Start () {
			init ();
			_audioSource =  (AudioSource)gameObject.GetComponent<AudioSource>();
			if (_audioSource == null && DefaultClickAudio != null) {
				_audioSource = (AudioSource)gameObject.AddComponent<AudioSource>();
				_audioSource.clip = DefaultClickAudio;
				_audioSource.playOnAwake = false;
				_needClickAudio = true;
			}

		}

		void OnDestroy()
		{
			if (onClick != null) {
				onClick.RemoveAllListeners ();
			}
		}

		public virtual void init()
		{
			initPosition = transform.localPosition;
			initRotation= transform.localRotation;
		}
		void  Update () {
		}



		public virtual void OnPointerDown(PointerEventData data)
		{
		}

		public virtual void OnPointerUp(PointerEventData data)
		{
		}

		public virtual void OnPointerClick(PointerEventData data)
		{
			if (onClick != null) {
				onClick.Invoke ();
			}
			if (_needClickAudio) {
				_audioSource.Play ();
			}
		}
			
		public virtual void OnDrag(PointerEventData data)
		{
		}


		public virtual void OnPointerEnter(PointerEventData eventData)
		{
			onMouseBeginAnimation ();
		}

		public virtual void OnPointerExit (PointerEventData eventData)
		{
			onMouseOutAnimation ();
		}

		void onMouseBeginAnimation()
		{
			switch (transition) {
			case Transition.Scale:
				transform.DOScale (initScal*scalNum, transitionTime).SetEase (Ease.InOutExpo).SetAutoKill(true);
				break;
			case Transition.Position:
				transform.DOLocalMove(initPosition+new Vector3(0,0,forwardNum*-1), transitionTime).SetEase (Ease.InOutExpo).SetAutoKill(true);
				break;
			}
		}

		void onMouseOutAnimation()
		{
			switch (transition) {
			case Transition.Scale:
				transform.DOScale (initScal, transitionTime).SetEase (Ease.InOutExpo).SetAutoKill(true);
				break;
			case Transition.Position:
				transform.DOLocalMove(initPosition, transitionTime).SetEase (Ease.InOutExpo).SetAutoKill(true);
				break;
			}
		}
	}
}
