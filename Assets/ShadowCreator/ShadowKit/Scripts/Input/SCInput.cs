

using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using LitJson;

namespace ShadowKit
{
	public class SCInput : PointerInputModule
	{
		public GameObject target{ private set; get;} //当前选中的物
		public Vector3 Normal{get;set;}//与碰撞点所在平面垂直的向量
		public float Distance{get;set;}
		public Vector3 Position {get;set;}
		public Vector3 MousePosition;
		public delegate void AnyKeyDown();
		public static event AnyKeyDown AnyKeyDownEvent;



		private static SCInput _instance;
		public static SCInput Instance
		{
			get
			{
				if ( _instance == null )
					_instance = GameObject.FindObjectOfType<SCInput>();
				return _instance;
			}
		}

		/// <summary>
		/// 执行焦点进入
		/// </summary>
		/// <param name="gameObject">Game object.</param>
		public void PointerEnter( GameObject gameObject )
		{
			PointerEventData pointerEventData = new PointerEventData( eventSystem );
			ExecuteEvents.Execute( gameObject, pointerEventData, ExecuteEvents.pointerEnterHandler );
		}
			
		/// <summary>
		/// 执行焦点移出
		/// </summary>
		/// <param name="gameObject">Game object.</param>
		public void PointerExit( GameObject gameObject )
		{
			PointerEventData pointerEventData = new PointerEventData( eventSystem );
			ExecuteEvents.Execute( gameObject, pointerEventData, ExecuteEvents.pointerExitHandler );
		}
			
		/// <summary>
		/// 按下
		/// </summary>
		/// <param name="gameObject">Game object.</param>
		public void PointDown(GameObject gameObject = null)
		{
			if (gameObject == null) {
				gameObject = target;
			}
			if (gameObject == null) {
				return;
			}
			PointerEventData pointerEventData = new PointerEventData (eventSystem);
			ExecuteEvents.Execute (gameObject, pointerEventData, ExecuteEvents.pointerDownHandler);
			ExecuteEvents.Execute(gameObject, pointerEventData, ExecuteEvents.pointerClickHandler);
		}

		/// <summary>
		/// 抬起
		/// </summary>
		/// <param name="gameObject">Game object.</param>
		public void PointUp(GameObject gameObject)
		{
			if (gameObject == null) {
				gameObject = target;
			}
			if (gameObject == null) {
				return;
			}
			PointerEventData pointerEventData = new PointerEventData (eventSystem);
			ExecuteEvents.Execute( gameObject, pointerEventData, ExecuteEvents.pointerUpHandler );
		}

		/// <summary>
		/// 拖动
		/// </summary>
		/// <param name="gameObject">Game object.</param>
		public void Drag(GameObject gameObject)
		{
			PointerEventData pointerEventData = new PointerEventData (eventSystem);
			ExecuteEvents.Execute( gameObject, pointerEventData, ExecuteEvents.dragHandler );
		}

		/// <summary>
		/// 任意键按下
		/// </summary>
		public void anyKeyDown()
		{
			if (AnyKeyDownEvent != null) {
				AnyKeyDownEvent ();
			}
		}

		//-------------------------------------------------
		public void SetTarget( GameObject gameObject )
		{
			target = gameObject;
		}
			
		//-------------------------------------------------
		public override void Process()
		{
		}
	}
}
