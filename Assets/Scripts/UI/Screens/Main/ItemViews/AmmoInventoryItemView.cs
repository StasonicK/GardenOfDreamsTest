using UI.Windows;
using UnityEngine;

namespace UI.Screens.Main.ItemViews
{
    public class AmmoInventoryItemView : BaseInventoryItemView
    {
        private string _countValue;

        public string CountValue => _countValue;

        public void Construct(string title, Sprite mainIcon, int count, int maxStackCount, float weight,
            Sprite traitIcon, InventoryItemWindow inventoryItemWindow)
        {
            base.Construct(title, mainIcon, count, maxStackCount, weight, traitIcon, inventoryItemWindow);
            _countValue = $"+{count}";
        }

        protected override void OnItemButtonClick() =>
            InventoryItemWindow.Show(Title, MainIcon, TraitIcon, CountValue, Weight);
    }
}