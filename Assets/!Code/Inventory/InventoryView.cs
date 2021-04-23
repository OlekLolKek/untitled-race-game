using System;
using System.Collections.Generic;
using UnityEngine;


namespace Inventory
{
    public class InventoryView : MonoBehaviour, IInventoryView
    {
        [SerializeField] private InventoryItemView _inventoryItemViewPrefab;
        private List<IItem> _itemInfoCollection;
        
        public event EventHandler<IItem> Selected;
        public event EventHandler<IItem> Deselected;
        
        public void Show()
        {
            Debug.Log("Show");
        }

        public void Hide()
        {
            Debug.Log("Hide");
        }
        
        public void Display(List<IItem> itemInfoCollection)
        {
            _itemInfoCollection = itemInfoCollection;

            for (int i = 0; i < _itemInfoCollection.Count; i++)
            {
                var position = Vector3.zero;
                position.x += _inventoryItemViewPrefab.Image.rectTransform.sizeDelta.x * i;
                var button = Instantiate(_inventoryItemViewPrefab, position, Quaternion.identity, transform);
                var i1 = i;
                button.Button.onClick.AddListener(() => OnItemButtonClicked(_itemInfoCollection[i1]));
            }
        }

        private void OnItemButtonClicked(IItem item)
        {
            Debug.Log($"Clicked: {item.IsSelected}");
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