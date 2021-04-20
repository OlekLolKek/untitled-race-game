using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Tools;
using UnityEngine;
using Object = UnityEngine.Object;


namespace Inventory
{
    public class InventoryController : BaseController, IInventoryController
    {
        private readonly ResourcePath _viewResourcePath = new ResourcePath {PathResource = "Prefabs/InventoryView"};
        private readonly IInventoryModel _inventoryModel;
        private readonly IItemsRepository _itemsRepository;
        private readonly IInventoryView _inventoryWindowView;

        public InventoryController(
            [NotNull] IInventoryModel inventoryModel)
        {
            _inventoryModel =
                inventoryModel ?? throw new ArgumentNullException(nameof(inventoryModel));
            var thingy = Resources.LoadAll<ItemConfig>("DataSource/").ToList();
            
            _itemsRepository = new ItemsRepository(thingy);
            
            //_inventoryModel.EquipItem();

            _inventoryWindowView = Object.Instantiate(
                ResourceLoader.LoadPrefab(_viewResourcePath)).
                GetComponent<IInventoryView>();

            ShowInventory(() => {});
        }

        public void ShowInventory(Action callback)
        {
            _inventoryWindowView.Display((List<IItem>)_inventoryModel.GetEquippedItems());
        }

        public void HideInventory()
        {
            throw new NotImplementedException();
        }
    }
}