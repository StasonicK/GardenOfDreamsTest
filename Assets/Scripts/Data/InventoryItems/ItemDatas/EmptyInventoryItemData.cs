using System.Runtime.Serialization;
using Data.InventoryItems.Ids;

namespace Data.InventoryItems.ItemDatas
{
    // [DataContract]
    [KnownType(typeof(EmptyInventoryItemData))]
    // [JsonConverter(typeof(InventoryItemDataConverter))]
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