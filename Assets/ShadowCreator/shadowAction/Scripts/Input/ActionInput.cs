using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ShadowKit.Action
{
	public enum ActionKeyCode{
		TIGGER = 16,
		POWER = 6,
        BACK = 32,
		TP = 5,
        VOLUMEDOWN = 9,
        VOLUMEUP = 8,
        OTHER = -1
	}
    
	public enum ActionKeyEvent{
		UP = 0,
		DOWN = 1,
		LONG = 2
	}

	public class ActionInput
	{
		public delegate void BluetoothHandleConnect(int deviceId);
		public static event BluetoothHandleConnect BluetoothHandleConnectEvent;

		public delegate void BluetoothHandleUnConnect(int deviceId);
		public static event  BluetoothHandleUnConnect BluetoothHandleUnConnectEvent;

		public delegate void EscapeDown();
		public static event EscapeDown EscapeDownEvent;

		public delegate void BluetoothHandleClick(ActionKeyCode code,ActionKeyEvent keyEvent,int deviceId);
		public static event BluetoothHandleClick BluetoothHandleClickEvent;

        public delegate void BluetoothHandleCombineClick();
        public static event BluetoothHandleCombineClick BluetoothHandleCombineClickEvent;

		public delegate void GestureFind();
		public static event GestureFind GestureFindEvent;

		public delegate void GestureLose();
		public static event GestureLose GestureLoseEvent;

		public delegate void SpeechAwake(string msg);
		public static event SpeechAwake SpeechAwakeEvent;

        public delegate void TouchBegin(int deviceId);
        public static event TouchBegin TouchBeginEvent;

        public delegate void TouchEnd(int deviceId);
        public static event TouchEnd TouchEndEvent;

        public delegate void TouchLeft(int deviceId);
        public static event TouchLeft TouchLeftEvent;
        public delegate void TouchRight(int deviceId);
        public static event TouchRight TouchRightEvent;
        public delegate void TouchUp(int deviceId);
        public static event TouchUp TouchUpEvent;
        public delegate void TouchDown(int deviceId);
        public static event TouchDown TouchDownEvent;

		private static Quaternion BluetoothHandleRotation1;
		private static Vector3 BluetoothHandleAngles1;
		private static Quaternion BluetoothHandleRotation2;
		private static Vector3 BluetoothHandleAngles2;
		private static bool isBluetoothHandleConnect1;
		private static bool isBluetoothHandleConnect2;
		public static Vector2[] DeviceTouchPosition = new Vector2[2] { Vector2.zero , Vector2.zero };
        public static Dictionary<ActionKeyCode, ActionKeyEvent> ActionKeys = new Dictionary<ActionKeyCode, ActionKeyEvent>() {
            {ActionKeyCode.TIGGER, ActionKeyEvent.UP},
            {ActionKeyCode.POWER, ActionKeyEvent.UP},
            {ActionKeyCode.BACK, ActionKeyEvent.UP},
            {ActionKeyCode.TP, ActionKeyEvent.UP},
            {ActionKeyCode.VOLUMEDOWN, ActionKeyEvent.UP},
            {ActionKeyCode.VOLUMEUP, ActionKeyEvent.UP},
            {ActionKeyCode.OTHER, ActionKeyEvent.UP},
        };
		public static void connected(int deviceId)
		{
			if (deviceId == 0) {
				isBluetoothHandleConnect1 = true;
				ActionSystem.Instance.BlueToothHandleConnected();
			}

			if (deviceId == 1) {
				isBluetoothHandleConnect2 = true;
			}
			if (BluetoothHandleConnectEvent != null) {
				BluetoothHandleConnectEvent (deviceId);
			}
		}

		public static void unConnected(int deviceId)
		{
			if (deviceId == 0) {
				isBluetoothHandleConnect1 = false;
				ActionSystem.Instance.BlueToothHandleUnConnected();
			}
			if (deviceId == 1) {
				isBluetoothHandleConnect2= false;
			}
			if (BluetoothHandleUnConnectEvent != null) {
				BluetoothHandleUnConnectEvent (deviceId);
			}
		}

		public static bool IsBluetoothHandleConnected(int deviceId)
		{
			if (deviceId == 0) {
				return isBluetoothHandleConnect1;
			}
			if (deviceId == 1) {
				return isBluetoothHandleConnect2;
			}
			return false;
		}

		public static Quaternion getBluetoothHandleRotation(int deviceId)
		{
			Quaternion res = new Quaternion ();
			if (deviceId == 0) {
				res = BluetoothHandleRotation1;
			}
			if (deviceId == 1) {
				res = BluetoothHandleRotation2;
			}
			return res;
		}

		public static void setBluetoothHandleRotation(Quaternion rotation, int deviceId)
		{
			if (deviceId == 0) {
				BluetoothHandleRotation1 = rotation;
			}
			if (deviceId == 1) {
				BluetoothHandleRotation2 = rotation;
			}
		}

		public static Vector3 getBluetoothHandleAngles(int index)
		{
			return getBluetoothHandleRotation (index).eulerAngles;
		}

		public static bool escapeDown()
		{
			if (EscapeDownEvent != null) {
				EscapeDownEvent ();
				return true;
			}
			return false;
		}

		public static void controllerClick(int keycode, int keyevent, int deviceId)
		{
			ActionKeyCode keyCode = ActionKeyCode.OTHER;
			ActionKeyEvent keyEvent = (ActionKeyEvent)keyevent;  
            switch ((ActionKeyCode)keycode) {
                case ActionKeyCode.BACK:
                    keyCode = ActionKeyCode.BACK;
                    break;
                case ActionKeyCode.TIGGER:
                    keyCode = ActionKeyCode.TIGGER;
                    break;
                case ActionKeyCode.POWER:
                    keyCode = ActionKeyCode.POWER;
                    break;
                case ActionKeyCode.TP:
                    keyCode = ActionKeyCode.TP;
                    break;
                case ActionKeyCode.VOLUMEDOWN:
                    keyCode = ActionKeyCode.VOLUMEDOWN;
                    break;
                case ActionKeyCode.VOLUMEUP:
                    keyCode = ActionKeyCode.VOLUMEUP;
                    break;
                default:
                    keyCode = ActionKeyCode.OTHER;
                    break;
            }
            UpdateKeysPressDictionary(keyCode, keyEvent, deviceId);
            if (BluetoothHandleClickEvent != null) {
                BluetoothHandleClickEvent(keyCode, keyEvent, deviceId);
            }
            if (BluetoothHandleCombineClickEvent != null) {
                BluetoothHandleCombineClickEvent();
            }
        }
        public static void onTouchBegin(int deviceId) {
            if (TouchBeginEvent != null) {
                TouchBeginEvent(deviceId);
            }
        }

        public static void onTouchEnd(int deviceId) {
            if (TouchEndEvent != null) {
                TouchEndEvent(deviceId);
            }
        }
        public static void onTouchLeft(int deviceId) {
            if (TouchLeftEvent != null) {
                TouchLeftEvent(deviceId);
            }
        }
        public static void onTouchRight(int deviceId) {
            if (TouchRightEvent != null) {
                TouchRightEvent(deviceId);
            }
        }
        public static void onTouchDown(int deviceId) {
            if (TouchDownEvent != null) {
                TouchDownEvent(deviceId);
            }
        }
        public static void onTouchUp(int deviceId) {
            if (TouchUpEvent != null) {
                TouchUpEvent(deviceId);
            }
        }


        public static void onGestureChange(bool haveHand)
		{
			if (haveHand && GestureFindEvent != null) {
				GestureFindEvent ();
			}
			if (!haveHand && GestureLoseEvent != null) {
				GestureLoseEvent ();
			}
		}

		public static void onSpeechAwake(string msg)
		{
			if (SpeechAwakeEvent != null) {
				SpeechAwakeEvent (msg);
			}
		}
        static void UpdateKeysPressDictionary(ActionKeyCode keyCode, ActionKeyEvent keyEvent, int deviceId) {
            if (deviceId != 0)
                return;

            if (keyEvent == ActionKeyEvent.DOWN) {
                if (SCInput.Instance.target != null) {
                    if (keyCode == ActionKeyCode.BACK) {
                        BackKeyDown(SCInput.Instance.target, null);
                    } else if (keyCode == ActionKeyCode.POWER) {
                        PowerKeyDown(SCInput.Instance.target, null);
                    } else if (keyCode == ActionKeyCode.TIGGER) {
                        TriggerKeyDown(SCInput.Instance.target, null);
                    } else if (keyCode == ActionKeyCode.TP) {
                        TouchKeyDown(SCInput.Instance.target, null);
                    } else if (keyCode == ActionKeyCode.VOLUMEDOWN) {
                        VolumeDownKeyDown(SCInput.Instance.target, null);
                    } else if (keyCode == ActionKeyCode.VOLUMEUP) {
                        VolumeUpKeyDown(SCInput.Instance.target, null);
                    }
                }
            } else if (keyEvent == ActionKeyEvent.UP) {
                if (SCInput.Instance.target != null) {
                    if (keyCode == ActionKeyCode.BACK) {
                        BackKeyUp(SCInput.Instance.target, null);
                    } else if (keyCode == ActionKeyCode.POWER) {
                        PowerKeyUp(SCInput.Instance.target, null);
                    } else if (keyCode == ActionKeyCode.TIGGER) {
                        TriggerKeyUp(SCInput.Instance.target, null);
                    } else if (keyCode == ActionKeyCode.TP) {
                        TouchKeyUp(SCInput.Instance.target, null);
                    } else if (keyCode == ActionKeyCode.VOLUMEDOWN) {
                        VolumeDownKeyUp(SCInput.Instance.target, null);
                    } else if (keyCode == ActionKeyCode.VOLUMEUP) {
                        VolumeUpKeyUp(SCInput.Instance.target, null);
                    }
                }
            }

            if (!ActionKeys.ContainsKey(keyCode)) {
                ActionKeys.Add(keyCode, ActionKeyEvent.UP);
            }
            if (keyEvent == ActionKeyEvent.LONG) {
                //keyEvent = ActionKeyEvent.DOWN;
            }
            ActionKeys[keyCode] = keyEvent;
        }

        public static void TriggerKeyDown(GameObject gameObject, PointerEventData pointerEventData, int deviceId = 0) {
            ExecuteEvents.Execute<ITriggerKeyDownHandler>(gameObject, pointerEventData, (x, y) => x.OnTriggerKeyDown(pointerEventData, deviceId));
        }
        public static void TriggerKeyUp(GameObject gameObject, PointerEventData pointerEventData, int deviceId = 0) {
            ExecuteEvents.Execute<ITriggerKeyUpHandler>(gameObject, pointerEventData, (x, y) => x.OnTriggerKeyUp(pointerEventData, deviceId));
        }
        public static void PowerKeyDown(GameObject gameObject, PointerEventData pointerEventData, int deviceId = 0) {
            ExecuteEvents.Execute<IPowerKeyDownHandler>(gameObject, pointerEventData, (x, y) => x.OnFunctionKeyDown(pointerEventData, deviceId));
        }
        public static void PowerKeyUp(GameObject gameObject, PointerEventData pointerEventData, int deviceId = 0) {
            ExecuteEvents.Execute<IPowerKeyUpHandler>(gameObject, pointerEventData, (x, y) => x.OnFunctionKeyUp(pointerEventData, deviceId));
        }
        public static void BackKeyDown(GameObject gameObject, PointerEventData pointerEventData, int deviceId = 0) {
            ExecuteEvents.Execute<IBackKeyDownHandler>(gameObject, pointerEventData, (x, y) => x.OnBackKeyDown(pointerEventData, deviceId));
        }
        public static void BackKeyUp(GameObject gameObject, PointerEventData pointerEventData, int deviceId = 0) {
            ExecuteEvents.Execute<IBackKeyUpHandler>(gameObject, pointerEventData, (x, y) => x.OnBackKeyUp(pointerEventData, deviceId));
        }
        public static void TouchKeyUp(GameObject gameObject, PointerEventData pointerEventData, int deviceId = 0) {
            ExecuteEvents.Execute<ITouchKeyDownHandler>(gameObject, pointerEventData, (x, y) => x.OnTouchKeyDown(pointerEventData, deviceId));
        }
        public static void TouchKeyDown(GameObject gameObject, PointerEventData pointerEventData, int deviceId = 0) {
            ExecuteEvents.Execute<ITouchKeyUpHandler>(gameObject, pointerEventData, (x, y) => x.OnTouchKeyUp(pointerEventData, deviceId));
        }
        public static void VolumeDownKeyDown(GameObject gameObject, PointerEventData pointerEventData, int deviceId = 0) {
            ExecuteEvents.Execute<IVolumeDownKeyDownHandler>(gameObject, pointerEventData, (x, y) => x.OnVolumeDownKeyDown(pointerEventData, deviceId));
        }
        public static void VolumeDownKeyUp(GameObject gameObject, PointerEventData pointerEventData, int deviceId = 0) {
            ExecuteEvents.Execute<IVolumeDownKeyUpHandler>(gameObject, pointerEventData, (x, y) => x.OnVolumeDownKeyUp(pointerEventData, deviceId));
        }
        public static void VolumeUpKeyDown(GameObject gameObject, PointerEventData pointerEventData, int deviceId = 0) {
            ExecuteEvents.Execute<IVolumeUpKeyDownHandler>(gameObject, pointerEventData, (x, y) => x.OnVolumeUpKeyDown(pointerEventData, deviceId));
        }
        public static void VolumeUpKeyUp(GameObject gameObject, PointerEventData pointerEventData, int deviceId = 0) {
            ExecuteEvents.Execute<IVolumeUpKeyUpHandler>(gameObject, pointerEventData, (x, y) => x.OnVolumeUpKeyUp(pointerEventData, deviceId));
        }
    }
}