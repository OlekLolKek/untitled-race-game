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
                Debug.Log(_inventoryItemViewPrefab.Image.flexibleWidth);
                Debug.Log(_inventoryItemViewPrefab.Image.minWidth);
                Debug.Log(_inventoryItemViewPrefab.Image.preferredWidth);
                Debug.Log(_inventoryItemViewPrefab.Image.rectTransform.sizeDelta.x);
                //position.x += 
                //Instantiate(_inventoryItemViewPrefab,  )
            }
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