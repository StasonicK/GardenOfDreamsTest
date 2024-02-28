using Data.InventoryItems.Ids;
using UI.Windows;
using UnityEngine;

namespace UI.Screens.Main.Inventory.ItemViews
{
    public class MedicineInventoryItemView : BaseInventoryItemView
    {
        private const string ACTIVATE_BUTTON_TEXT = "Лечить";

        public int Heal { private set; get; }
        public MedicineId Id { private set; get; }
        public string HealValue { private set; get; }

        public void Construct(string title, Sprite mainIcon, int count, int maxStackCount, float weight,
            int heal, Sprite traitIcon, MedicineId medicineId, InventoryItem inventoryItem,
            InventoryItemWindow inventoryItemWindow)
        {
            base.Construct(title, mainIcon, count, maxStackCount, weight, traitIcon, inventoryItem,
                inventoryItemWindow);
            Id = medicineId;
            Heal = heal;
            HealValue = $"{heal} HP";
        }

        protected override void OnItemButtonClick() =>
            InventoryItemWindow.Show(Title, MainIcon, TraitIcon, HealValue, Weight, ACTIVATE_BUTTON_TEXT,
                InventoryItem);

        public override void TryStack(InventoryItem thisInventoryItem, InventoryItem targetItem)
        {
            switch (thisInventoryItem.InventoryItemId)
            {
                case InventoryItemId.Empty:
                    targetItem.ShowMedicineInventoryItem(Title, MainIcon, Count, MaxStackCount, Weight, Heal, TraitIcon,
                        Id, InventoryItemWindow);
                    targetItem.InventoryCell.SetInventoryItemId(InventoryItemId.Medicine);
                    thisInventoryItem.ShowEmptyInventoryItem();
                    thisInventoryItem.InventoryCell.SetInventoryItemId(InventoryItemId.Empty);
                    break;
                case InventoryItemId.Medicine:
                {
                    if (targetItem.MedicineInventoryItemView.Id == Id)
                    {
                        int targetCount = targetItem.MedicineInventoryItemView.Count;

                        if (targetCount == MaxStackCount)
                        {
                            thisInventoryItem.Return(true);
                            return;
                        }

                        int difference = MaxStackCount - targetCount;

                        if (Count > difference)
                        {
                            targetItem.MedicineInventoryItemView.AddCount(difference);
                            RemoveCount(difference);
                            thisInventoryItem.Return(true);
                        }
                        else
                        {
                            targetItem.MedicineInventoryItemView.AddCount(Count);
                            thisInventoryItem.ShowEmptyInventoryItem();
                            thisInventoryItem.InventoryCell.SetInventoryItemId(InventoryItemId.Empty);
                            thisInventoryItem.Return(false);
                        }
                    }
                    else
                    {
                        thisInventoryItem.Return(true);
                    }

                    break;
                }
                case InventoryItemId.Ammo:
                case InventoryItemId.Headgear:
                case InventoryItemId.Outerwear:
                    thisInventoryItem.Return(true);
                    break;
            }
        }
    }
}