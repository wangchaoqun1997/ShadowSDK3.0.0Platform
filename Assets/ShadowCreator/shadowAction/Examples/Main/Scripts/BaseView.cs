using ShadowKit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BaseView :BaseWindow  {

    public object config;
    public bool isSelect;

    public override void Start() {
        base.Start();
        isSelect = false;
        AddEvent();
    }

    public override void Init() {
        
    }

    public void AddEvent() {
        if (!gameObject.GetComponent<SCButton>()) {
            gameObject.AddComponent<SCButton>();
        }
        EventManager.RemoveAllTriggerListener(gameObject);
        EventManager.AddTriggerListener(gameObject, EventTriggerType.PointerEnter,OnEnter);
        EventManager.AddTriggerListener(gameObject, EventTriggerType.PointerDown, OnDown);
        EventManager.AddTriggerListener(gameObject, EventTriggerType.PointerUp, OnUp);
        EventManager.AddTriggerListener(gameObject, EventTriggerType.PointerExit, OnExit);
        EventManager.AddTriggerListener(gameObject, EventTriggerType.PointerClick, OnClick);
    }

    public virtual void OnEnter(BaseEventData data) {

    }
    public virtual void OnDown(BaseEventData data) {

    }
    public virtual void OnUp(BaseEventData data) {

    }
    public virtual void OnExit(BaseEventData data) {

    }
    public virtual void OnClick(BaseEventData data) {

    }
    public virtual void Refresh() {

    }
}
