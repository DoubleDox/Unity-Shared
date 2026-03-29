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