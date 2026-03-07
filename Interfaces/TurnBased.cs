
public interface ITurnBasedActor
{
    int CellsPerAction { get; }

    void Consume(int consume = 1, string customCounter = null, bool canUseBase = true);

    int AP { get; set; }

    int GetMaxDist(string customCounter = null, bool canUseBase = true);

    int GetCustomAP(string customCounter, bool canUseBase);

    int GetAPMovementLeft(int dist, string customCounter = null, bool canUseBaseAP = true);

    bool Enabled { get; set; }


    void Refill();
}