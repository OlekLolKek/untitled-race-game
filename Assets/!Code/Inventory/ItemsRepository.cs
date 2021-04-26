using System.Collections.Generic;
using Garage;
using UnityEngine;


namespace Inventory
{
    public class ItemsRepository : BaseController, IRepository<int, IItem>
    {
        public IReadOnlyDictionary<int, IItem> Collection => _itemsMapById;
        private Dictionary<int, IItem> _itemsMapById = new Dictionary<int, IItem>();

        public ItemsRepository(List<ItemConfig> upgradeItemConfigs)
        {
            PopulateItems(ref _itemsMapById, upgradeItemConfigs);
        }

        protected override void OnDispose()
        {
            base.OnDispose();
            _itemsMapById.Clear();
            _itemsMapById = null;
        }

        #region Methods

        private void PopulateItems(ref Dictionary<int, IItem> upgradeHandlersMapByType,
            List<ItemConfig> configs)
        {
            foreach (var config in configs)
            {
                Debug.Log($"{config.ID} {config.Title}");
                if (!upgradeHandlersMapByType.ContainsKey(config.ID))
                {
                    upgradeHandlersMapByType.Add(config.ID, CreateItem(config));
                }
            }
        }

        private IItem CreateItem(ItemConfig config)
        {
            return new Item
            {
                Id = config.ID,
                Info = new ItemInfo
                {
                    Title = config.Title,
                    Description = config.Description,
                    Icon = config.Icon
                }
            };
        }

        #endregion
    }
}