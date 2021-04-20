using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Inventory
{
    public class InventoryTextView : MonoBehaviour, IInventoryView
    {
        [SerializeField] private Text _text;
        
        public event EventHandler<IItem> Selected;
        public event EventHandler<IItem> Deselected;
        
        public void Display(List<IItem> items)
        {
            _text.text = $"Items count: {items.Count}";
        }
    }
}