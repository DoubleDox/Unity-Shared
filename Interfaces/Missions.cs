using System.Collections.Generic;
using UnityEngine;

public interface IMissionHolder
{
    bool IsEnabled { get; }

    int InternalID { get; }

    void StoreProps(Dictionary<string, string> props);
}

public interface IMissionsPack
{
    List<IMissionHolder> Missions { get; }
}
