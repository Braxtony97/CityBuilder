namespace Domain.Events
{
    public class BuildingRemovedEvent
    {
        public readonly int BuildingId;

        public BuildingRemovedEvent(int buildingId)
        {
            BuildingId = buildingId;
        }
    }
}
