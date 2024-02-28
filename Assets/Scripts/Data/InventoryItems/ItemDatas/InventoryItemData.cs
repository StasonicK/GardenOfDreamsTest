using System.Runtime.Serialization;
using Data.InventoryItems.Ids;

namespace Data.InventoryItems.ItemDatas
{
    [DataContract]
    public class InventoryItemData
    {
        public InventoryItemId InventoryItemId;

        public InventoryItemData()
        {
        }

        public InventoryItemData(InventoryItemId inventoryItemId)
        {
            InventoryItemId = inventoryItemId;
        }
    }
}