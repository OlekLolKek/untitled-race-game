using System;
using System.Collections.Generic;
using Inventory;
using UI;


namespace Abilities
{
    public interface IAbilityCollectionView : IView
    {
        event EventHandler<IItem> UseRequested;
        void Display(IReadOnlyList<IItem> abilityItems);
    }
}