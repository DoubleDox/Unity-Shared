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