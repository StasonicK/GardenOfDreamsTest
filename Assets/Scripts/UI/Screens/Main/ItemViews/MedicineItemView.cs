using Data.InventoryItems.Ids;
using UI.Windows;
using UnityEngine;

namespace UI.Screens.Main.ItemViews
{
    public class MedicineItemView : InventoryItemView
    {
        private float _healValue;

        public float HealValue => _healValue;

        public void Construct(string title, Sprite icon, int count, int maxStackCount, float weight,
            InventoryItemId inventoryItemId, float healValue, Sprite traitIcon, InventoryItemWindow inventoryItemWindow)
        {
            base.Construct(title, icon, count, maxStackCount, weight, inventoryItemId, traitIcon, inventoryItemWindow);
            _healValue = healValue;
        }

        protected override void OnItemButtonClick() =>
            InventoryItemWindow.Show(Title, MainIcon, TraitIcon, _healValue.ToString(), Weight);
    }
}