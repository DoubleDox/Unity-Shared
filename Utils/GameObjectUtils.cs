// -----------------------------------
// author: DoubleDox, parax_85@mail.ru
// -----------------------------------
using UnityEngine;
using System.Collections;

public static class GameObjectUtils
{
    public static GameObject GetGameObject(Object obj)
    {
        if (obj is GameObject) return obj as GameObject;
        if (obj is MonoBehaviour) return (obj as MonoBehaviour).gameObject;
        if (obj is Collider) return (obj as Collider).gameObject;
        return null;
    }

    public static void SetLayer(GameObject go, int layer)
    {
        go.layer = layer;
        for (int i = 0; i < go.transform.childCount; i++)
        {
            SetLayer(go.transform.GetChild(i).gameObject, layer);
        }
    }

    public static GameObject AddChild(GameObject template, Transform parent = null)
    {
        var inst = GameObject.Instantiate(template);
        inst.transform.SetParent(parent ?? template.transform.parent);
        inst.transform.localScale = template.transform.localScale;
        inst.transform.localPosition = template.transform.localPosition;
        inst.transform.localRotation = template.transform.localRotation;
        inst.SetActive(true);
        return inst;
    }

    public static T AddChildScript<T>(T template, Transform parent = null) where T : MonoBehaviour
    {
        var inst = AddChild(template.gameObject, parent);
        return inst.GetComponent<T>();
    }

    public static T Find<T>(System.Predicate<T> match, Transform parent = null) where T : MonoBehaviour
    {
        if (parent == null)
            return System.Array.Find<T>(GameObject.FindObjectsOfType<T>(), match);
        else
            return System.Array.Find<T>(parent.GetComponentsInChildren<T>(true), match);
    }

    public static T[] FindAll<T>(System.Predicate<T> match, Transform parent = null) where T : MonoBehaviour
    {
        if (parent == null)
            return System.Array.FindAll<T>(GameObject.FindObjectsOfType<T>(), match);
        else
            return System.Array.FindAll<T>(parent.GetComponentsInChildren<T>(true), match);
    }
}
