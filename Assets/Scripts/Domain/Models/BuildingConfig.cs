using System.Collections.Generic;

namespace Domain.Models
{
    public class BuildingConfig
    {
        private readonly Dictionary<BuildingType, BuildingData> _buildings;

        public BuildingConfig(Dictionary<BuildingType, BuildingData> buildings)
        {
            _buildings = buildings;
        }

        public BuildingData Get(BuildingType type)
        {
            return _buildings[type];
        }
    }
}