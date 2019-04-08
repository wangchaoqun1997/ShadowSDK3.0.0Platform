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

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void OnEnter(object parameter = null) {
        
        base.OnEnter(parameter);
        mainInfo.text = parameter as string;
    }

    public override void OnExit(object parameter = null) {
        base.OnExit(parameter);
        mainInfo.text = "";
    }

    public void CloseButtonFuntion() {
        PlatformUISystem.Instant.uiPanelsManager.PopUIPanel();
    }

    public void EnterButtonFuntion() {
        PlatformUISystem.Instant.uiPanelsManager.PopUIPanel();
    }
}
