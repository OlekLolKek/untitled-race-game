using System;
using System.Collections.Generic;
using System.Linq;
using Inventory;
using JetBrains.Annotations;
using Profile;
using UnityEngine;


namespace Garage
{
    internal class ShedController : BaseController, IShedController
    {
        private readonly IUpgradable _upgradable;

        private readonly IRepository<int, IUpgradeHandler> _upgradeHandlersRepository;
        private readonly IRepository<int, IUpgradeHandler> _defaultHandlers;
        private readonly IRepository<int, IItem> _itemsRepository;
        private readonly IInventoryController _inventoryController;

        public ShedController(
            [NotNull] IRepository<int, IUpgradeHandler> upgradeHandlersRepository,
            [NotNull] IRepository<int, IUpgradeHandler> defaultHandlers,
            [NotNull] IRepository<int, IItem> itemsRepository,
            [NotNull] IInventoryController inventoryController,
            [NotNull] IUpgradable upgradable)
        {
            _upgradeHandlersRepository =
                upgradeHandlersRepository ??
                throw new ArgumentNullException(nameof(upgradeHandlersRepository));
            
            _defaultHandlers =
                defaultHandlers ??
                throw new ArgumentNullException(nameof(defaultHandlers));

            _itemsRepository =
                itemsRepository ??
                throw new ArgumentNullException(nameof(itemsRepository));

            _inventoryController =
                inventoryController ??
                throw new ArgumentNullException(nameof(inventoryController));

            _upgradable =
                upgradable ??
                throw new ArgumentNullException(nameof(upgradable));

            _inventoryController.HideInventory();
        }

        private void UpgradeCarWithEquippedItems(
            IUpgradable upgradable,
            IReadOnlyList<IItem> items,
            IReadOnlyDictionary<int, IUpgradeHandler> upgradeHandlers,
            IReadOnlyDictionary<int, IUpgradeHandler> defaultHandlers)
        {
            if (items.Count == 0)
            {
                _upgradable.Restore();
            }
            
            Debug.Log(items.Count);
            foreach (var item in items)
            {
                if (item.IsSelected)
                {
                    if (upgradeHandlers.TryGetValue(item.Id, out var handler))
                    {
                        handler.Upgrade(upgradable);
                    }
                }
                else
                {
                    if (defaultHandlers.TryGetValue(item.Id, out var defaultHandler))
                    {
                        defaultHandler.Upgrade(upgradable);
                    }
                }
            }
        }

        public void Enter()
        {
            _inventoryController.ShowInventory(Exit);
            Debug.Log($"Enter: car speed is {_upgradable.Speed}");
        }

        public void Exit()
        {
            UpgradeCarWithEquippedItems(
                _upgradable,
                _itemsRepository.Collection.Values.ToList(),
                _upgradeHandlersRepository.Collection,
                _defaultHandlers.Collection
                );
            Debug.Log($"Exit: car speed is {_upgradable.Speed}");
        }

        #region Overrides of BaseController

        protected override void OnDispose()
        {
            base.OnDispose();
            Exit();
        }

        #endregion
    }
}