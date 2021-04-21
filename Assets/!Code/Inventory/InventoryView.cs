using System;
using System.Collections.Generic;
using UnityEngine;


namespace Inventory
{
    public class InventoryView : MonoBehaviour, IInventoryView
    {
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