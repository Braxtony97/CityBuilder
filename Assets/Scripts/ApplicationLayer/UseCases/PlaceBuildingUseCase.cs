using ApplicationLayer.Services;
using Domain.Models;
using VContainer;

namespace ApplicationLayer.UseCases
{
    public class PlaceBuildingUseCase
    {
        private readonly BuildingConfig _buildingConfig;
        private readonly GridService _grid;
        private readonly EconomyService _economy;

        [Inject]
        public PlaceBuildingUseCase(
            BuildingConfig buildingConfig,
            GridService grid,
            EconomyService economy)
        {
            _buildingConfig = buildingConfig; 
            _grid = grid;
            _economy = economy;
        }

        public bool TryPlaceBuilding(BuildingType type, int x, int y)
        {
            var cell = _grid.GetCell(x, y);
            if (cell.IsOccupied) return false;

            var data = _buildingConfig.Get(type);
            if (!_economy.CanSpend(data.BaseCost)) return false;

            _economy.Spend(data.BaseCost);
            cell.IsOccupied = true;

            // TODO: через MessagePipe отправляем событие "BuildingPlaced"
            return true;
        }
    }
}