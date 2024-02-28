using System.Runtime.Serialization;
using Data.InventoryItems.Ids;

namespace Data.InventoryItems.ItemDatas
{
    // [DataContract]
    [KnownType(typeof(OuterwearInventoryItemData))]
    // [JsonConverter(typeof(InventoryItemDataConverter))]
    public class OuterwearInventoryItemData : FilledInventoryItemData
    {
        // [DataMember] 
        public OuterwearId Id;

        public OuterwearInventoryItemData()
        {
        }

        public OuterwearInventoryItemData(int count, OuterwearId id) : base(count, InventoryItemId.Outerwear)
        {
            Id = id;
        }
    }
}