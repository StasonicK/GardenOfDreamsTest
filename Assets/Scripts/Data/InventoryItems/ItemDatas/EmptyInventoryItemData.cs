using System.Runtime.Serialization;
using Data.InventoryItems.Ids;

namespace Data.InventoryItems.ItemDatas
{
    [KnownType(typeof(EmptyInventoryItemData))]
    public class EmptyInventoryItemData : InventoryItemData
    {
        public EmptyInventoryItemData()
        {
        }

        public EmptyInventoryItemData(InventoryItemId inventoryItemId) : base(inventoryItemId)
        {
        }
    }
}