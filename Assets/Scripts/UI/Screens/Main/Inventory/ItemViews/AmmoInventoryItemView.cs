using Data.InventoryItems.Ids;
using UI.Windows;
using UnityEngine;

namespace UI.Screens.Main.Inventory.ItemViews
{
    public class AmmoInventoryItemView : BaseInventoryItemView
    {
        private const string ACTIVATE_BUTTON_TEXT = "Купить";

        public AmmoId Id { private set; get; }

        public void Construct(string title, Sprite mainIcon, int count, int maxStackCount, float weight,
            Sprite traitIcon, AmmoId ammoId, InventoryItem inventoryItem,
            InventoryItemWindow inventoryItemWindow)
        {
            Id = ammoId;
            base.Construct(title, mainIcon, count, maxStackCount, weight, traitIcon, inventoryItem,
                inventoryItemWindow);
        }

        protected override void OnItemButtonClick()
        {
            InventoryItemWindow.gameObject.SetActive(true);
            InventoryItemWindow.SetData(Title, MainIcon, TraitIcon, $"+{Count}", Weight, ACTIVATE_BUTTON_TEXT,
                InventoryItem);
            // WindowsManager.Instance.Show(WindowId.InventoryItemWindowId);
        }

        public override void TryStack(InventoryItem thisInventoryItem, InventoryItem targetItem)
        {
            switch (thisInventoryItem.InventoryItemId)
            {
                case InventoryItemId.Empty:
                    targetItem.ShowAmmoInventoryItem(Title, MainIcon, Count, MaxStackCount, Weight, TraitIcon, Id,
                        InventoryItemWindow);
                    thisInventoryItem.ShowEmptyInventoryItem();
                    break;
                case InventoryItemId.Ammo:
                {
                    if (targetItem.AmmoInventoryItemView.Id == Id)
                    {
                        int targetCount = targetItem.AmmoInventoryItemView.Count;

                        if (targetCount == MaxStackCount)
                        {
                            thisInventoryItem.Return(true);
                            return;
                        }

                        int difference = MaxStackCount - targetCount;

                        if (Count > difference)
                        {
                            targetItem.AmmoInventoryItemView.AddCount(difference);
                            RemoveCount(difference);
                            thisInventoryItem.Return(true);
                        }
                        else
                        {
                            targetItem.AmmoInventoryItemView.AddCount(Count);
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
                case InventoryItemId.Headgear:
                case InventoryItemId.Outerwear:
                case InventoryItemId.Medicine:
                    thisInventoryItem.Return(true);
                    break;
            }
        }
    }
}