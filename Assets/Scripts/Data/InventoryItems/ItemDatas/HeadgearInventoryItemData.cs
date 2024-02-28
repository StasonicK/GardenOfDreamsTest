using System.Runtime.Serialization;
using Data.InventoryItems.Ids;

namespace Data.InventoryItems.ItemDatas
{
    // [DataContract]
    [KnownType(typeof(HeadgearInventoryItemData))]
    // [JsonConverter(typeof(InventoryItemDataConverter))]
    public class HeadgearInventoryItemData : FilledInventoryItemData
    {
        // [DataMember] 
        public HeadgearId Id;

        public HeadgearInventoryItemData()
        {
        }

        public HeadgearInventoryItemData(int count, HeadgearId id) : base(count, InventoryItemId.Headgear)
        {
            Id = id;
        }
    }
}