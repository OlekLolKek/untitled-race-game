using System.Collections.Generic;
using Inventory;


namespace Garage
{
    public class UpgradeHandlersRepository : IRepository<int, IUpgradeHandler>
    {
        public IReadOnlyDictionary<int, IUpgradeHandler> Collection 
            => _upgradeItemsMapById;
        
        private readonly Dictionary<int, IUpgradeHandler> _upgradeItemsMapById 
            = new Dictionary<int, IUpgradeHandler>();

        public UpgradeHandlersRepository(List<UpgradeItemConfig> upgradeItemConfigs)
        {
            PopulateItems(ref _upgradeItemsMapById, upgradeItemConfigs);
        }

        private void PopulateItems(
            ref Dictionary<int, IUpgradeHandler> upgradeHandlersMapByType,
            List<UpgradeItemConfig> configs)
        {
            foreach (var config in configs)
            {
                if (!upgradeHandlersMapByType.ContainsKey(config.ID))
                {
                    upgradeHandlersMapByType.Add(config.ID, CreateHandlerByType(config));
                }
            }
        }

        private IUpgradeHandler CreateHandlerByType(UpgradeItemConfig config)
        {
            switch (config.Type)
            {
                case UpgradeType.Speed:
                    return new SpeedUpgradeHandler(config.Value);
                default:
                    return StubUpgradeHandler.Default;
            }
        }
    }
}