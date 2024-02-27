using UnityEngine;

namespace UI.Screens.Main.Inventory
{
    public class InventoryCell : MonoBehaviour
    {
        public InventoryItem InventoryItem { private set; get; }

        public void SetInventoryItem(InventoryItem inventoryItem) =>
            InventoryItem = inventoryItem;
    }
}