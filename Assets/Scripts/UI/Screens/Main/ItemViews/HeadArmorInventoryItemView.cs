using Data.InventoryItems.Ids;
using UI.Windows;
using UnityEngine;

namespace UI.Screens.Main.ItemViews
{
    public class HeadArmorInventoryItemView : InventoryItemView
    {
        // private float _defenseValue;
        private string _defenseValue;

        // public float DefenseValue => _defenseValue;
        public string DefenseValue => _defenseValue;

        public void Construct(string title, Sprite icon, int count, int maxStackCount, float weight,
            InventoryItemId inventoryItemId, float defenseValue, Sprite traitIcon,
            InventoryItemWindow inventoryItemWindow)
        {
            base.Construct(title, icon, count, maxStackCount, weight, inventoryItemId, traitIcon, inventoryItemWindow);
            // _defenseValue = defenseValue;
            _defenseValue = $"+{defenseValue}";
        }

        protected override void OnItemButtonClick() =>
            InventoryItemWindow.Show(Title, MainIcon, TraitIcon, _defenseValue, Weight);
    }
}