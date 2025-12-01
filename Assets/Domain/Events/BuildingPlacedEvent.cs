using UnityEngine;

public class BuildingPlacedEvent
{
    public readonly int BuildingId;
    public readonly Vector2Int Position;

    public BuildingPlacedEvent(int buildingId, Vector2Int position)
    {
        BuildingId = buildingId;
        Position = position;
    }
}
