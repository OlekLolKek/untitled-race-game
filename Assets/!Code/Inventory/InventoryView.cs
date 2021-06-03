using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Inventory
{
    public class InventoryView : MonoBehaviour, IInventoryView
    {
        [SerializeField] private InventoryItemView _inventoryItemViewPrefab;
        [SerializeField] private Button _backButton;
        [SerializeField] private Transform _itemsRoot;
        private List<IItem> _itemInfoCollection;
        
        public event EventHandler<IItem> Selected;
        public event EventHandler<IItem> Deselected;
        public event Action InventoryClosed;

        public void Initialize()
        {
            _backButton.onClick.AddListener(OnBackButtonClicked);
        }
        
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
        
        public void Display(List<IItem> itemInfoCollection)
        {
            _itemInfoCollection = itemInfoCollection;

            for (int i = 0; i < _itemInfoCollection.Count; i++)
            {
                var button = Instantiate(_inventoryItemViewPrefab, _itemsRoot);
                button.Image.sprite = itemInfoCollection[i].Info.Icon;
                var i1 = i;
                //button.Button.onClick.AddListener(() => OnItemButtonClicked(_itemInfoCollection[i1]));
                button.Toggle.onValueChanged.AddListener(value => OnItemToggleValueChanged(value, _itemInfoCollection[i1]));
                button.Toggle.isOn = _itemInfoCollection[i].IsSelected;
            }
        }

        private void OnItemButtonClicked(IItem item)
        {
            if (item.IsSelected)
            {
                OnDeselected(item);
            }
            else
            {
                OnSelected(item);
            }

            item.IsSelected = !item.IsSelected;
        }

        private void OnItemToggleValueChanged(bool value, IItem item)
        {
            item.IsSelected = value;
            
            if (item.IsSelected)
            {
                OnSelected(item);
            }
            else
            {
                OnDeselected(item);
            }
        }

        private void OnBackButtonClicked()
        {
            InventoryClosed?.Invoke();
        }

        protected virtual void OnSelected(IItem e)
        {
            Selected?.Invoke(this, e);
        }
        
        protected virtual void OnDeselected(IItem e)
        {
            Deselected?.Invoke(this, e);
        }
    }
}