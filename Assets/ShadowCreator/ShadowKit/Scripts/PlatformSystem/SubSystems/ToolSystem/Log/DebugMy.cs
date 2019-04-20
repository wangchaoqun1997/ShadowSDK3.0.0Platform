using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public static class DebugMy {

    public static void Log(string msg,object o) {
        if (o == null) {
            Debug.Log(msg);
        } else {
            Debug.Log("[" + o.GetType().ToString() + "]: " + msg);
        }
        
    }

    public static void LogError(string msg, object o) {
        if (o == null) {
            Debug.LogError(msg);
        } else {
            Debug.LogError("[" + o.GetType().ToString() + "]: " + msg);
        }
    }
}