// -----------------------------------
// author: DoubleDox, parax_85@mail.ru
// -----------------------------------
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class AnalyticsWrapperBase : MonoBehaviour
{
    static List<AnalyticsWrapperBase> wrappers = new List<AnalyticsWrapperBase>();

    protected static string userId;

    protected virtual void Awake()
    {
        wrappers.Add(this);
    }

    protected virtual void OnDestroy()
    {
        wrappers.Remove(this);
    }

    protected virtual void onLogin()
    {

    }

    protected abstract void sendEvent(string eventType, Dictionary<string,object> data = null);
    
    public static void SendEvent(string eventType, Dictionary<string, object> data = null)
    {
        foreach (var wr in wrappers)
            wr.sendEvent(eventType, data);
    }

    public static void OnLogin(string uid)
    {
        userId = uid;
        foreach (var wr in wrappers)
            wr.onLogin();
    }
}
