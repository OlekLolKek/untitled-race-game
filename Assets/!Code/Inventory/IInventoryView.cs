using System;
using System.Collections.Generic;
using UI;


namespace Inventory
{
    public interface IInventoryView : IView
    {
        event EventHandler<IItem> Selected;
        event EventHandler<IItem> Deselected;
        void Display(List<IItem> itemInfoCollection);
    }
}