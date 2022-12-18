using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDebugInfo : MonoBehaviour
{
    [SerializeField]
    private Text template;

    public static UIDebugInfo instance;

    private void Awake()
    {
        instance = this;

        template.gameObject.SetActive(false);
    }

    Dictionary<string, Text> holders = new Dictionary<string, Text>();
    Dictionary<string, float> lastUpdate = new Dictionary<string, float>();

    private void Update()
    {
        string toRemove = null;
        foreach (var kvp in lastUpdate)
        {
            if (Time.time > kvp.Value + 3f)
            {
                toRemove = kvp.Key;
            }
        }

        if (toRemove != null)
        {
            lastUpdate.Remove(toRemove);
            GameObject.Destroy(holders[toRemove].gameObject);
            holders.Remove(toRemove);
        }
    }

    private void CheckCreate(string key)
    {
        if (!holders.ContainsKey(key))
        {
            var inst = GameObjectUtils.AddChild(template.gameObject);
            holders.Add(key, inst.GetComponent<Text>());
            lastUpdate.Add(key, Time.time);
        }
    }

    public static void Show(string key, float value)
    {
        if (instance != null)
        {
            instance.CheckCreate(key);
            instance.holders[key].text = key + ": " + value.ToString();
        }
    }

    public static void Show(string key, int value)
    {
        if (instance != null)
        {
            instance.CheckCreate(key);
            instance.holders[key].text = key + ": " + value.ToString();
        }
    }
}


public interface IDurableHolder
{
    string GetString();
}