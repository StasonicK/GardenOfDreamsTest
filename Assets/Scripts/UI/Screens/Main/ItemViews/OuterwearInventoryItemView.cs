using UI.Windows;
using UnityEngine;

namespace UI.Screens.Main.ItemViews
{
    public class OuterwearInventoryItemView : BaseInventoryItemView
    {
        // private float _defenseValue;
        private string _defenseValue;

        // public float DefenseValue => _defenseValue;
        public string DefenseValue => _defenseValue;

        public void Construct(string title, Sprite mainIcon, int count, int maxStackCount, float weight,
            float defenseValue,
            Sprite traitIcon, InventoryItemWindow inventoryItemWindow)
        {
            base.Construct(title, mainIcon, count, maxStackCount, weight, traitIcon, inventoryItemWindow);
            // _defenseValue = defenseValue;
            _defenseValue = $"+{defenseValue}";
        }

        protected override void OnItemButtonClick() =>
            InventoryItemWindow.Show(Title, MainIcon, TraitIcon, _defenseValue.ToString(), Weight);
    }
}