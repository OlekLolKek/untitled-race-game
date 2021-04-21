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
        private readonly IInventoryController _inventoryController;

        public ShedController(
            [NotNull] IRepository<int, IUpgradeHandler> upgradeHandlersRepository,
            [NotNull] IInventoryController inventoryController,
            [NotNull] IUpgradable upgradable)
        {
            _upgradeHandlersRepository = 
                upgradeHandlersRepository ?? 
                throw new ArgumentNullException(nameof(upgradeHandlersRepository));

            _inventoryController =
                inventoryController ??
                throw new ArgumentNullException(nameof(inventoryController));

            _upgradable =
                upgradable ??
                throw new ArgumentNullException(nameof(upgradable));
        }

        private void UpgradeCarWithEquippedItems(
            IUpgradable upgradable,
            IReadOnlyList<IItem> equippedItems,
            IReadOnlyDictionary<int, IUpgradeHandler> upgradeHandlers)
        {
            foreach (var equippedItem in equippedItems)
            {
                if (upgradeHandlers.TryGetValue(equippedItem.Id, out var handler))
                {
                    handler.Upgrade(upgradable);
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
                _inventoryController.GetEquippedItems(),
                _upgradeHandlersRepository.Collection);
            Debug.Log($"Exit: car speed is {_upgradable.Speed}");
        }
    }
}