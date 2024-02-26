using Data.InventoryItems.Ids;

namespace UI.Screens.Main.Inventory.ItemViews
{
    public class EmptyInventoryItemView : BaseInventoryItemView
    {
        public override void TryStack(InventoryItem thisInventoryItem, InventoryItem targetItem)
        {
            switch (thisInventoryItem.InventoryItemId)
            {
                case InventoryItemId.Ammo:
                    targetItem.ShowAmmoInventoryItem(
                        thisInventoryItem.AmmoInventoryItemView.Title,
                        thisInventoryItem.AmmoInventoryItemView.MainIcon,
                        thisInventoryItem.AmmoInventoryItemView.Count,
                        thisInventoryItem.AmmoInventoryItemView.MaxStackCount,
                        thisInventoryItem.AmmoInventoryItemView.Weight,
                        thisInventoryItem.AmmoInventoryItemView.TraitIcon,
                        thisInventoryItem.AmmoInventoryItemView.Id,
                        thisInventoryItem.AmmoInventoryItemView.InventoryItemWindow);
                    thisInventoryItem.ShowEmptyInventoryItem();
                    break;
                case InventoryItemId.Headgear:
                    targetItem.ShowHeadgearInventoryItem(
                        thisInventoryItem.HeadgearInventoryItemView.Title,
                        thisInventoryItem.HeadgearInventoryItemView.MainIcon,
                        thisInventoryItem.HeadgearInventoryItemView.Count,
                        thisInventoryItem.HeadgearInventoryItemView.MaxStackCount,
                        thisInventoryItem.HeadgearInventoryItemView.Weight,
                        thisInventoryItem.HeadgearInventoryItemView.Defense,
                        thisInventoryItem.HeadgearInventoryItemView.TraitIcon,
                        thisInventoryItem.HeadgearInventoryItemView.Id,
                        thisInventoryItem.HeadgearInventoryItemView.InventoryItemWindow);
                    thisInventoryItem.ShowEmptyInventoryItem();
                    break;
                case InventoryItemId.Outerwear:
                    targetItem.ShowOuterwearInventoryItem(
                        thisInventoryItem.OuterwearInventoryItemView.Title,
                        thisInventoryItem.OuterwearInventoryItemView.MainIcon,
                        thisInventoryItem.OuterwearInventoryItemView.Count,
                        thisInventoryItem.OuterwearInventoryItemView.MaxStackCount,
                        thisInventoryItem.OuterwearInventoryItemView.Weight,
                        thisInventoryItem.OuterwearInventoryItemView.Defense,
                        thisInventoryItem.OuterwearInventoryItemView.TraitIcon,
                        thisInventoryItem.OuterwearInventoryItemView.Id,
                        thisInventoryItem.OuterwearInventoryItemView.InventoryItemWindow);
                    thisInventoryItem.ShowEmptyInventoryItem();
                    break;
                case InventoryItemId.Medicine:
                    targetItem.ShowMedicineInventoryItem(
                        thisInventoryItem.MedicineInventoryItemView.Title,
                        thisInventoryItem.MedicineInventoryItemView.MainIcon,
                        thisInventoryItem.MedicineInventoryItemView.Count,
                        thisInventoryItem.MedicineInventoryItemView.MaxStackCount,
                        thisInventoryItem.MedicineInventoryItemView.Weight,
                        thisInventoryItem.MedicineInventoryItemView.Heal,
                        thisInventoryItem.MedicineInventoryItemView.TraitIcon,
                        thisInventoryItem.MedicineInventoryItemView.Id,
                        thisInventoryItem.MedicineInventoryItemView.InventoryItemWindow);
                    thisInventoryItem.ShowEmptyInventoryItem();
                    break;
            }

            thisInventoryItem.Return(false);
        }
    }
}