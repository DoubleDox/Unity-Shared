using System.Collections.Generic;
using UnityEngine;

public class GameEventHandler<T>
{
    List<T> handlers = new List<T>();

    public GameEventHandler()
    {

    }

    public void AddHandler(T handler)
    {
        if (!handlers.Contains(handler))
            handlers.Add(handler);
    }

    public void RemoveHandler(T handler)
    {
        if (handlers.Contains(handler))
            handlers.Remove(handler);
    }

    public void SendEvent(System.Action<T> doFunc, MonoBehaviour self = null)
    {
        if (self != null && !self.Equals(null))
        {
            var list = self.GetComponents<T>();
            for (int i = 0; i < list.Length; i++)
            {
                doFunc(list[i]);
            }
        }
        for (int i = 0; i < handlers.Count; i++)
        {
            doFunc(handlers[i]);
        }
    }
}

