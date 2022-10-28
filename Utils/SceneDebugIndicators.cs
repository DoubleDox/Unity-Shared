// -----------------------------------
// author: DoubleDox, parax_85@mail.ru
// -----------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDebugIndicators : MonoBehaviour
{
    public static SceneDebugIndicators instance;

    [SerializeField]
    float showTimeout = 300;

    [SerializeField]
    List<IndicatorResource> indicators = new List<IndicatorResource>();

    List<IndicatorInstance> instances = new List<IndicatorInstance>();

    const string SHOW_DEBUG_INDICATORS_PARAM = "showDebugIndicators";

    private void Awake()
    {
        instance = this;
#if !UNITY_EDITOR
        gameObject.SetActive(false);
#endif
    }

    private bool IsEnabled
    {
        get
        {
#if UNITY_EDITOR
            return UnityEditor.EditorPrefs.GetBool(SHOW_DEBUG_INDICATORS_PARAM, false);
#else
            return false;
#endif
        }
    }

    public GameObject ShowMark(string indicator, Vector3 position, Vector3 to)
    {
        var inst = ShowMark(indicator, position);
        if (inst != null)
        {
            var dir = to - position;
            inst.transform.localScale = new Vector3(inst.transform.localScale.x, inst.transform.localScale.y, inst.transform.localScale.z * dir.magnitude);
            inst.transform.LookAt(to);
        }
        return inst;
    }

    public GameObject ShowMark(string indicator, Vector3 position)
    {
        if (IsEnabled && gameObject.activeSelf)
        {
            var template = indicators.Find(i => i.name == indicator);
            if (template != null)
            {
                var inst = GameObjectUtils.AddChild(template.template, transform);
                inst.transform.position = position;
                instances.Add(new IndicatorInstance() { indicator = inst, ttl = showTimeout });
                return inst;
            }
            else
                Debug.LogError("Template not found for indicator " + indicator);
        }
        return null;
    }

    private void Update()
    {
        foreach (var ind in instances)
        {
            ind.ttl -= Time.deltaTime;
            if (ind.ttl < 0)
            {
                GameObject.Destroy(ind.indicator);
                instances.Remove(ind);
                break;
            }
        }
    }

    public void Clear()
    {
        foreach (var ind in instances)
        {
            GameObject.Destroy(ind.indicator);
        }
        instances.Clear();
    }


    [Serializable]
    public class IndicatorResource
    {
        public string name;
        public GameObject template;
    }

    public class IndicatorInstance
    {
        public GameObject indicator;
        public float ttl;
    }

#if UNITY_EDITOR
    [UnityEditor.MenuItem("Custom/DebugIndicators/Enable")]
    public static void SetEnable()
    {
        UnityEditor.EditorPrefs.SetBool(SHOW_DEBUG_INDICATORS_PARAM, true);
    }

    [UnityEditor.MenuItem("Custom/DebugIndicators/Disable")]
    public static void SetDisable()
    {
        UnityEditor.EditorPrefs.SetBool(SHOW_DEBUG_INDICATORS_PARAM, false);
    }

    [UnityEditor.MenuItem("Custom/DebugIndicators/Clear")]
    public static void ClearAll()
    {
        if (SceneDebugIndicators.instance != null)
        {
            SceneDebugIndicators.instance.Clear();
        }
    }
#endif
}
