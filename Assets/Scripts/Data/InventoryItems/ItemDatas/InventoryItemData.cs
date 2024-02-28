using System.Runtime.Serialization;
using Data.InventoryItems.Ids;

namespace Data.InventoryItems.ItemDatas
{
    [DataContract]
    // [KnownType(typeof(EmptyInventoryItemData))]
    // [KnownType(typeof(AmmoInventoryItemData))]
    // [KnownType(typeof(HeadgearInventoryItemData))]
    // [KnownType(typeof(OuterwearInventoryItemData))]
    // [KnownType(typeof(MedicineInventoryItemData))]
    // [JsonConverter(typeof(InventoryItemDataConverter))]
    public class InventoryItemData
    {
        // [DataMember]
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