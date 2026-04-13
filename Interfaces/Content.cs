
using System.Collections.Generic;
using UnityEngine;

public interface ITileable
{
    List<Vector2Int> GetTiles(ContentTileSetup setup);
}

public struct ContentTileSetup
{
    public Vector2 center;
    public Vector2 tileSize;
    public Vector2Int offset;

    public Vector2Int PositionToTile(Vector3 position)
    {
        return new Vector2Int(positionToSector(position.x, center.x, tileSize.x, offset.x),
            positionToSector(position.z, center.y, tileSize.y, offset.y));
    }
    int positionToSector(float pos, float center, float size, int offset)
    {
        return Mathf.RoundToInt((pos - center) / size) + offset;
    }
}