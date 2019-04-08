using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ShadowKit.Action {
    public interface ITriggerKeyDownHandler : IEventSystemHandler {
        void OnTriggerKeyDown(PointerEventData eventData, int deviceId = 0);
    }
    public interface ITriggerKeyUpHandler : IEventSystemHandler {
        void OnTriggerKeyUp(PointerEventData eventData, int deviceId = 0);
    }
    public interface IPowerKeyDownHandler : IEventSystemHandler {
        void OnFunctionKeyDown(PointerEventData eventData, int deviceId = 0);
    }
    public interface IPowerKeyUpHandler : IEventSystemHandler {
        void OnFunctionKeyUp(PointerEventData eventData, int deviceId = 0);
    }
    public interface IBackKeyDownHandler : IEventSystemHandler {
        void OnBackKeyDown(PointerEventData eventData, int deviceId = 0);
    }
    public interface IBackKeyUpHandler : IEventSystemHandler {
        void OnBackKeyUp(PointerEventData eventData, int deviceId = 0);
    }
    public interface ITouchKeyDownHandler : IEventSystemHandler {
        void OnTouchKeyDown(PointerEventData eventData, int deviceId = 0);
    }
    public interface ITouchKeyUpHandler : IEventSystemHandler {
        void OnTouchKeyUp(PointerEventData eventData, int deviceId = 0);
    }
    public interface IVolumeDownKeyDownHandler : IEventSystemHandler {
        void OnVolumeDownKeyDown(PointerEventData eventData, int deviceId = 0);
    }
    public interface IVolumeDownKeyUpHandler : IEventSystemHandler {
        void OnVolumeDownKeyUp(PointerEventData eventData, int deviceId = 0);
    }
    public interface IVolumeUpKeyDownHandler : IEventSystemHandler {
        void OnVolumeUpKeyDown(PointerEventData eventData, int deviceId = 0);
    }
    public interface IVolumeUpKeyUpHandler : IEventSystemHandler {
        void OnVolumeUpKeyUp(PointerEventData eventData, int deviceId = 0);
    }
}