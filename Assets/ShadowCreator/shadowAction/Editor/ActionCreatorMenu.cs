using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace ShadowKit.Action
{
	public class ActionCreatorMenu : Editor {

//		[MenuItem("Tools/ShadowCreator/Air")]
		public static void createAir()
		{
			GameObject added = GameObject.Find ("ShadowSystem");
			GameObject obj;
			GameObject sel;
			if (added == null) {
				obj = (GameObject)Resources.Load ("Prefabs/ShadowSystem");
				sel = (GameObject)Instantiate (obj);
				sel.name = "ShadowSystem";
			}
		
			added = GameObject.Find ("AirSystem");
			if (added == null) {
				obj = (GameObject)Resources.Load ("Prefabs/AirSystem");
				sel = (GameObject)Instantiate (obj);
				sel.name = "AirSystem";
			}
		
		}

		[MenuItem("Tools/ShadowCreator/Action")]
		public static void createAction()
		{
			GameObject added = GameObject.Find ("ShadowSystem");
			GameObject obj;
			GameObject sel;
			if (added != null) {
				DestroyImmediate (added);
			}
			obj = (GameObject)Resources.Load ("Prefabs/ShadowSystem");
			sel = (GameObject)Instantiate (obj);
			sel.name = "ShadowSystem";

			added = GameObject.Find ("ActionSystem");
			if (added != null) {
				DestroyImmediate (added);
			}

			obj = (GameObject)Resources.Load ("Prefabs/ActionSystem");
			sel = (GameObject)Instantiate (obj);
			sel.name = "ActionSystem";
		}

//		[MenuItem("ShadowCreator/Objects/Window")]
//		public static void createWindow()
//		{
//			GameObject obj = (GameObject)Resources.Load ("Prefabs/Window");
//			Instantiate (obj);
//			var select = obj.gameObject;
//			Material material = new Material(Shader.Find("Standard"));
//			var pb = PrefabUtility.GetPrefabParent (select);
//			if (pb == null) {
//				return;
//			}
//			PrefabUtility.DisconnectPrefabInstance(select);
//			Selection.activeGameObject = null;
//			var prefab = PrefabUtility.CreateEmptyPrefab("Assets/empty.prefab");
//			PrefabUtility.ReplacePrefab(select, prefab, ReplacePrefabOptions.ConnectToPrefab);
//			PrefabUtility.DisconnectPrefabInstance(select);
//		}
//			
//		[MenuItem("ShadowCreator/Objects/Panel")]
//		public static void creatorPanel()
//		{
//			GameObject btn = (GameObject)Resources.Load ("Prefabs/Panel");
//			Instantiate (btn);
//			var select = btn.gameObject;
//			Material material = new Material(Shader.Find("Standard"));
//			var pb = PrefabUtility.GetPrefabParent (select);
//			if (pb == null) {
//				return;
//			}
//			PrefabUtility.DisconnectPrefabInstance(select);
//			Selection.activeGameObject = null;
//			var prefab = PrefabUtility.CreateEmptyPrefab("Assets/empty.prefab");
//			PrefabUtility.ReplacePrefab(select, prefab, ReplacePrefabOptions.ConnectToPrefab);
//			PrefabUtility.DisconnectPrefabInstance(select);
//		}

	}
}
