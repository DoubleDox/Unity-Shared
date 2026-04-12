using System.Collections.Generic;

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