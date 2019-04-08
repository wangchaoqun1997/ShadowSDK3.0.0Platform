using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickObj : MonoBehaviour {

	public TextMesh text;
	// Use this for initialization
	void Start () {
		text.text = "请选中方块";
		GetComponent<MeshRenderer> ().materials [0].color = Color.white;
	}

	public void onClick()
	{
		float r = Random.Range (0, 255) / 255.0f;
		float g = Random.Range (0, 255) / 255.0f;
		float b = Random.Range (0, 255) / 255.0f;
		GetComponent<MeshRenderer> ().materials [0].color = new Color (r, g, b);
	}

	public void onEnter()
	{
		text.text = "点击手柄按键更换颜色";
	}

	public void onExit()
	{
		text.text = "请选中方块";
		GetComponent<MeshRenderer> ().materials [0].color = Color.white;
	}
}
