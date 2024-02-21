using Data.InventoryItems.Ids;
using UI.Windows;
using UnityEngine;

namespace UI.Screens.Main.ItemViews
{
    public class AmmoItemView : InventoryItemView
    {
        public void Construct(string title, Sprite mainIcon, int count, int maxStackCount, float weight,
            InventoryItemId inventoryItemId, Sprite traitIcon, InventoryItemWindow inventoryItemWindow)
        {
            base.Construct(title, mainIcon, count, maxStackCount, weight, inventoryItemId, traitIcon,
                inventoryItemWindow);
        }

        protected override void OnItemButtonClick() =>
            InventoryItemWindow.Show(Title, MainIcon, TraitIcon, Count.ToString(), Weight);
    }
}