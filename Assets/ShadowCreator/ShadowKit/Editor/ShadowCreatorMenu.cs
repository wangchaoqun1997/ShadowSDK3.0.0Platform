using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace ShadowKit
{
	public class ShadowCreatorMenu : Editor {

		[MenuItem("GameObject/ShadowCreator/SCButton", false, 18)]
		public static void SCButtonCreate()
		{
			GameObject obj = (GameObject)Resources.Load ("Prefabs/GameObjects/SCButton");
			GameObject sel = (GameObject)Instantiate (obj);
			sel.name = "SCButton";
			Transform curTransform = Selection.activeTransform;
			if (curTransform != null) {
				sel.transform.parent = curTransform;
			}
			sel.transform.localRotation = new Quaternion ();
			sel.transform.localPosition = Vector3.zero;
			sel.transform.localScale = Vector3.one;
		}

		private static GameObject Canvas;
		[MenuItem("GameObject/ShadowCreator/Canvas", false, 19)]
		public static void CanvasCreate()
		{
			GameObject obj = (GameObject)Resources.Load ("Prefabs/GameObjects/Canvas");
			GameObject sel = (GameObject)Instantiate (obj);
			sel.name = "Canvas";
			Transform curTransform = Selection.activeTransform;
			if (curTransform != null) {
				sel.transform.parent = curTransform;
			}
			sel.transform.localRotation = new Quaternion ();
			sel.transform.localPosition = Vector3.zero;
			sel.transform.localScale = Vector3.one * 0.001f;
			Canvas = sel;
		}
			
		[MenuItem("GameObject/ShadowCreator/UIButton", false, 20)]
		public static void UIButtonCreate()
		{
			if (Canvas == null) {
				Canvas c = Transform.FindObjectOfType<Canvas> ();
				if (c != null) {
					Canvas = c.gameObject;
				}
				if (Canvas == null) {
					CanvasCreate ();
				}
			}

			GameObject obj = (GameObject)Resources.Load ("Prefabs/GameObjects/UIButton");
			GameObject sel = (GameObject)Instantiate (obj);
			sel.name = "UIButton";
			sel.transform.parent = Canvas.transform;
			sel.transform.localRotation = new Quaternion ();
			sel.transform.localPosition = Vector3.zero;
			sel.transform.localScale = Vector3.one;
		}

		[MenuItem("GameObject/ShadowCreator/SCInputField", false, 21)]
		public static void SCInputFieldCreate()
		{
			if (Canvas == null) {
				Canvas c = Transform.FindObjectOfType<Canvas> ();
				if (c != null) {
					Canvas = c.gameObject;
				}
				if (Canvas == null) {
					CanvasCreate ();
				}
			}
			GameObject obj = (GameObject)Resources.Load ("Prefabs/GameObjects/SCInputField");
			GameObject sel = (GameObject)Instantiate (obj);
			sel.name = "SCInputField";
			sel.transform.parent = Canvas.transform;
			sel.transform.localRotation = new Quaternion ();
			sel.transform.localPosition = Vector3.zero;
			sel.transform.localScale = Vector3.one;
		}

		[MenuItem("GameObject/ShadowCreator/SCKeyboard", false, 22)]
		public static void SCKeyboardCreate()
		{
			if (Canvas == null) {
				Canvas c = Transform.FindObjectOfType<Canvas> ();
				if (c != null) {
					Canvas = c.gameObject;
				}
				if (Canvas == null) {
					CanvasCreate ();
				}
			}
			GameObject obj = (GameObject)Resources.Load ("Prefabs/GameObjects/SCKeyboard");
			GameObject sel = (GameObject)Instantiate (obj);
			sel.name = "SCKeyboard";
			sel.transform.parent = Canvas.transform;
			sel.transform.localRotation = new Quaternion ();
			sel.transform.localPosition = Vector3.zero;
			sel.transform.localScale = Vector3.one;
		}
	}
}
