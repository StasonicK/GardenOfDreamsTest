using Data.InventoryItems.Ids;
using UnityEngine;

namespace UI.Screens.Main.Inventory
{
    public class InventoryCell : MonoBehaviour
    {
        public InventoryItem InventoryItem { private set; get; }
        public InventoryItemId InventoryItemId { private set; get; }

        public void SetInventoryItemId(InventoryItemId inventoryItemId) =>
            InventoryItemId = inventoryItemId;

        public void SetInventoryItem(InventoryItem inventoryItem, InventoryItemId inventoryItemId)
        {
            InventoryItem = inventoryItem;
            InventoryItemId = inventoryItemId;
            InventoryItem.SetInventoryCell(this);
        }
    }
}