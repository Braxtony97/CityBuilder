using System.Collections.Generic;

namespace Domain.Models
{
    public class BuildingData
    {
        public BuildingType Type { get; }
        public int BaseCost { get; }
        public IReadOnlyList<BuildingLevelData> Levels { get; }
        
        public BuildingData(BuildingType type, int baseCost, List<BuildingLevelData> levels)
        {
            Type = type;
            BaseCost = baseCost;
            Levels = levels;
        }
    }
}