using System.Collections.Generic;
using Inventory;


namespace Garage
{
    public class UpgradeHandlersRepository : BaseController
    {
        public IReadOnlyDictionary<int, IUpgradeHandler> UpgradeItems 
            => _upgradeItemsMapById;
        
        private Dictionary<int, IUpgradeHandler> _upgradeItemsMapById 
            = new Dictionary<int, IUpgradeHandler>();

        public UpgradeHandlersRepository(List<UpgradeItemConfig> upgradeItemConfigs)
        {
            PopulateItems(ref _upgradeItemsMapById, upgradeItemConfigs);
        }

        protected override void OnDispose()
        {
            _upgradeItemsMapById.Clear();
            _upgradeItemsMapById = null;
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