using UI.Windows;
using UnityEngine;

namespace UI.Screens.Main.ItemViews
{
    public class MedicineInventoryItemView : BaseInventoryItemView
    {
        // private float _healValue;
        private string _healValue;

        // public float HealValue => _healValue;
        public string HealValue => _healValue;

        public void Construct(string title, Sprite mainIcon, int count, int maxStackCount, float weight,
            float healValue,
            Sprite traitIcon, InventoryItemWindow inventoryItemWindow)
        {
            base.Construct(title, mainIcon, count, maxStackCount, weight, traitIcon, inventoryItemWindow);
            // _healValue = healValue;
            _healValue = $"{healValue} HP";
        }

        protected override void OnItemButtonClick() =>
            InventoryItemWindow.Show(Title, MainIcon, TraitIcon, _healValue, Weight);
    }
}