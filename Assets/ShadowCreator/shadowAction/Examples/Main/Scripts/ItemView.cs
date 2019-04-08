using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemView : EffectView {

    public AScene aScene;

    public override void Start() {
        base.Start();
    }

    public override void Refresh() {
        aScene = (AScene)config;
        title.text = aScene.title;
        info.text = aScene.info;
    }

    public override void OnClick(BaseEventData data) {
        base.OnClick(data);
        if (aScene != null) {
            aScene.LoadSceneAsync();
        }
        
    }
    
}
