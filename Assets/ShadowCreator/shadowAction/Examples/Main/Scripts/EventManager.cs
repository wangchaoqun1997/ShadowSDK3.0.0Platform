using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class EventManager {

    private static EventManager mInstant;
    public static EventManager Instant {
        get {
            if (mInstant == null) {
                mInstant = new EventManager();
            }
            return mInstant;
        }
    }

    public static  void AddTriggerListener(GameObject obj,EventTriggerType eventId, UnityAction<BaseEventData> action) {
        if (obj.GetComponent<EventTrigger>() == null) {
            obj.AddComponent<EventTrigger>();
        }

        var trigger = obj.GetComponent<EventTrigger>();
        foreach (EventTrigger.Entry _entry in trigger.triggers) {
            if (_entry.eventID == eventId) {
                Debug.Log("注册了"+eventId +"事件");
                break;
            }
        }
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = eventId;
        entry.callback.AddListener(action);
        //entry.callback.AddListener((data) => { action(data); });
        trigger.triggers.Add(entry);
    }

    public static void RemoveTriggerListener(GameObject obj, EventTriggerType eventId) {

        var trigger = obj.GetComponent<EventTrigger>();
        if (!trigger) {
            Debug.Log(obj+"没有EventTrigger组件");
            return;
        }
        foreach (EventTrigger.Entry _entry in trigger.triggers) {
            if (_entry.eventID == eventId) {
                trigger.triggers.Remove(_entry);
                Debug.Log("移除"+eventId+"事件");
            }
        }
    }

    public static void RemoveAllTriggerListener(GameObject obj) {
        var trigger = obj.GetComponent<EventTrigger>();
        if (!trigger) {
            Debug.Log(obj + "没有EventTrigger组件");
            return;
        }
        trigger.triggers.Clear();
    }

}
