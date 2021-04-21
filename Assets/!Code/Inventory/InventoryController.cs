using System;
using System.Collections.Generic;
using System.Linq;
using Garage;
using JetBrains.Annotations;
using Tools;
using UnityEngine;
using Object = UnityEngine.Object;


namespace Inventory
{
    public class InventoryController : BaseController, IInventoryController
    {
        private readonly IRepository<int, IItem> _itemsRepository;
        private readonly IInventoryModel _inventoryModel;
        private readonly IInventoryView _inventoryView;
        private Action _hideAction;

        public InventoryController(
            [NotNull] IRepository<int, IItem> itemsRepository,
            [NotNull] IInventoryModel inventoryModel,
            [NotNull] IInventoryView inventoryView)
        {
            _itemsRepository
                = itemsRepository ?? throw new ArgumentNullException(nameof(itemsRepository));
            
            _inventoryModel 
                = inventoryModel ?? throw new ArgumentNullException(nameof(inventoryModel));
            
            _inventoryView
                = inventoryView ?? throw new ArgumentNullException(nameof(_inventoryView));
        }

        protected override void OnDispose()
        {
            CleanupView();
            base.OnDispose();
        }

        public IReadOnlyList<IItem> GetEquippedItems()
        {
            return _inventoryModel.GetEquippedItems();
        }

        public void ShowInventory(Action hideAction)
        {
            _hideAction = hideAction;
            _inventoryView.Show();
            _inventoryView.Display(_itemsRepository.Collection.Values.ToList());
        }

        public void HideInventory()
        {
            _inventoryView.Hide();
            _hideAction?.Invoke();
        }

        private void SetupView(IInventoryView inventoryView)
        {
            inventoryView.Selected += OnItemSelected;
            inventoryView.Deselected += OnItemDeselected;
        }

        private void CleanupView()
        {
            _inventoryView.Selected -= OnItemSelected;
            _inventoryView.Deselected -= OnItemDeselected;
        }

        private void OnItemSelected(object sender, IItem item)
        {
            _inventoryModel.EquipItem(item);
        }

        private void OnItemDeselected(object sender, IItem item)
        {
            _inventoryModel.UnequipItem(item);
        }
    }
}