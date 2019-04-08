using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeObj : MonoBehaviour {

	public TextMesh text;
	// Use this for initialization
	void Start () {
		text.text = "请转动头部将光标移向方块上";
		GetComponent<MeshRenderer> ().materials [0].color = Color.red;
	}

	public void onAutoClick()
	{
		text.text = "自动凝视已触发";
		GetComponent<MeshRenderer> ().materials [0].color = Color.green;
	}

	public void onEnter()
	{
		text.text = "光标已选中方块\n请等待两秒触发自动凝视";
	}

	public void onExit()
	{
		text.text = "请转动头部将光标移向方块";
		GetComponent<MeshRenderer> ().materials [0].color = Color.red;
	}
}
