using System;
using System.Collections.Generic;
using UnityEngine;

public interface IResource
{
    string Id { get; }

    public static string GetId(GameObject go)
    {
        if (go != null && go.TryGetComponent<IResource>(out var r))
            return r.Id;
        return null;
    }
}

public interface IStatHolder
{
    int Current { get; }
    int Max { get; }
    float Ratio => Max > 0 ? Current * 1.0f / Max : 0;
    event Action<int, int> OnChanged;
}

public class StatProxy : IStatHolder
{
    private Func<int> _cur, _max;
    public StatProxy(Func<int> c, Func<int> m) { _cur = c; _max = m; }
    public int Current => _cur();
    public int Max => _max();

    public event Action<int, int> OnChanged;
    public void NotifyChanged() => OnChanged?.Invoke(Current, Max);
}

public interface IGameObjectProcessor
{
    void Process(GameObject go);
}

public interface IJsonStateHolder
{
    void StoreState(Dictionary<string, object> state);

    void ReadState(Dictionary<string, object> state);
}

public interface IRadiusHolder
{
    float Radius { get; }
}

public interface IInputListener
{
    bool IsControllable { get; set; }

    //int InputSlot { get; }
}

public interface IComponentHolder
{
    bool TryGetComponent<T>(out T value);

    T GetComponent<T>();
}