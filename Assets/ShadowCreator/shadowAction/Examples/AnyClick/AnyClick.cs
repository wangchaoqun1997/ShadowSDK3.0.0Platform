using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ShadowKit;
using ShadowKit.Action;

public class AnyClick : MonoBehaviour {

	private int clickCount = 0;

	// Use this for initialization
	void Start () {
		GetComponent<MeshRenderer> ().materials [0].color = Color.white;
        
		SCInput.AnyKeyDownEvent += onClick;
	}

	public void onClick()
	{
		float r = Random.Range (0, 255) / 255.0f;
		float g = Random.Range (0, 255) / 255.0f;
		float b = Random.Range (0, 255) / 255.0f;

		GetComponent<MeshRenderer> ().materials [0].color = new Color (r, g, b);
	}
    void OnDestroy() {
        SCInput.AnyKeyDownEvent -= onClick;
    }

}
