using Data.InventoryItems.Ids;
using UI.Windows;
using UnityEngine;

namespace UI.Screens.Main.Inventory.ItemViews
{
    public class OuterwearInventoryItemView : BaseInventoryItemView
    {
        private const string ACTIVATE_BUTTON_TEXT = "Экипировать";

        public int Defense { private set; get; }
        public OuterwearId Id { private set; get; }
        public string DefenseValue { private set; get; }

        public void Construct(string title, Sprite mainIcon, int count, int maxStackCount, float weight,
            int defense, Sprite traitIcon, OuterwearId outerwearId, InventoryItem inventoryItem,
            InventoryItemWindow inventoryItemWindow)
        {
            Defense = defense;
            Id = outerwearId;
            DefenseValue = $"+{defense}";
            base.Construct(title, mainIcon, count, maxStackCount, weight, traitIcon, inventoryItem,
                inventoryItemWindow);
        }

        protected override void OnItemButtonClick() =>
            InventoryItemWindow.Show(Title, MainIcon, TraitIcon, DefenseValue, Weight, ACTIVATE_BUTTON_TEXT,
                InventoryItem);

        public override void TryStack(InventoryItem thisInventoryItem, InventoryItem targetItem)
        {
            switch (thisInventoryItem.InventoryItemId)
            {
                case InventoryItemId.Empty:
                    targetItem.ShowOuterwearInventoryItem(Title, MainIcon, Count, MaxStackCount, Weight, Defense,
                        TraitIcon, Id, InventoryItemWindow);
                    thisInventoryItem.ShowEmptyInventoryItem();
                    break;
                case InventoryItemId.Outerwear:
                {
                    if (targetItem.OuterwearInventoryItemView.Id == Id)
                    {
                        int targetCount = targetItem.OuterwearInventoryItemView.Count;

                        if (targetCount == MaxStackCount)
                        {
                            thisInventoryItem.Return(true);
                            return;
                        }

                        int difference = MaxStackCount - targetCount;

                        if (targetCount > difference)
                        {
                            targetItem.OuterwearInventoryItemView.AddCount(difference);
                            RemoveCount(difference);
                            thisInventoryItem.Return(true);
                        }
                        else
                        {
                            targetItem.OuterwearInventoryItemView.AddCount(Count);
                            thisInventoryItem.ShowEmptyInventoryItem();
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
                case InventoryItemId.Medicine:
                    thisInventoryItem.Return(true);
                    break;
            }
        }
    }
}