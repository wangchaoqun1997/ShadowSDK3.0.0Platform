using Assets.ShadowCreator.ShadowKit.Scripts.PlatformSystem.UI;
using ShadowKit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoBaseUI : BaseUIPanel {

    public SCButton enterButton;
    public SCButton closeButton;
    public Text mainInfo;
    private Stack<string> mainInfoStack;

    public InfoBaseUI() {
        mainInfoStack = new Stack<string>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void OnEnter(object parameter = null) {
        
        base.OnEnter(parameter);
        mainInfo.text = parameter as string;
        mainInfoStack.Push(mainInfo.text);
    }

    public override void OnExit(object parameter = null) {
        base.OnExit(parameter);
        mainInfo.text = "";
        mainInfoStack.Pop();
    }

    public override void OnResume(object parameter = null) {
        base.OnResume(parameter);
        mainInfo.text = mainInfoStack.Peek();

    }

    public void CloseButtonFuntion() {
        PlatformUISystem.Instant.uiPanelsManager.PopUIPanel();
    }

    public void EnterButtonFuntion() {
        PlatformUISystem.Instant.uiPanelsManager.PopUIPanel();
    }
}
