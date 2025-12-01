using System.Collections.Generic;

namespace Domain.Models
{
    public class BuildingConfigFactory
    {
        public static BuildingConfig Create()
        {
            var buildings = new Dictionary<BuildingType, BuildingData>();
            
            buildings[BuildingType.Tower] = new BuildingData(
                BuildingType.Tower,
                200,
                new List<BuildingLevelData>
                {
                    new(level: 1, upgradeCost: 100, goldPerMinute: 3),
                    new(level: 2, upgradeCost: 200, goldPerMinute: 6),
                }
            );
            
            buildings[BuildingType.House] = new BuildingData(
                BuildingType.House,
                100,
                new List<BuildingLevelData>
                {
                    new(level: 1, upgradeCost: 50, goldPerMinute: 1),
                    new(level: 2, upgradeCost: 100, goldPerMinute: 2),
                }
            );
            
            buildings[BuildingType.Farm] = new BuildingData(
                BuildingType.Farm,
                150,
                new List<BuildingLevelData>
                {
                    new(level: 1, upgradeCost: 75, goldPerMinute: 2),
                    new(level: 2, upgradeCost: 150, goldPerMinute: 4),
                }
            );
            
            return new BuildingConfig(buildings);
        }
    }
}