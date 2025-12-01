namespace Domain.Models
{
    public class BuildingLevelData
    {
        public int Level { get; }
        public int UpgradeCost { get; }
        public int GoldPerMinute { get; }

        public BuildingLevelData(int level, int upgradeCost, int goldPerMinute)
        {
            Level = level;
            UpgradeCost = upgradeCost;
            GoldPerMinute = goldPerMinute;
        }
    }
}