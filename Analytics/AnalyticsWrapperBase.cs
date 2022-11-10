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

    public delegate void AnalyticsDataProcessor(Dictionary<string, object> data);

    public static AnalyticsDataProcessor DataPreProcessor { get; set; }
    
    [SerializeField]
    private AnalyticsEventMap[] eventsMap;

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


    public static void SendEvent(string eventType, Dictionary<string, string> data)
    {
        var dataObj = new Dictionary<string, object>();
        foreach (var kvp in data)
            dataObj.Add(kvp.Key, kvp.Value);
        SendEvent(eventType, dataObj);
    }

    public static void SendEvent(string eventType, Dictionary<string, object> data = null)
    {
        DataPreProcessor?.Invoke(data);

        foreach (var wr in wrappers)
        {
            string platformBasedEvent = eventType;
            if (wr.eventsMap != null)
            {
                for (int i = 0; i < wr.eventsMap.Length; i++)
                    if (wr.eventsMap[i].source == eventType)
                    {
                        platformBasedEvent = wr.eventsMap[i].send;
                    }
            }

            if (!string.IsNullOrEmpty(platformBasedEvent))
                wr.sendEvent(platformBasedEvent, data);
        }
    }

    public static void OnLogin(string uid)
    {
        userId = uid;
        foreach (var wr in wrappers)
            wr.onLogin();
    }
}

[System.Serializable]
public class AnalyticsEventMap
{
    public string source;
    public string send;
}