using System.Runtime.Serialization;
using Data.InventoryItems.Ids;

namespace Data.InventoryItems.ItemDatas
{
    // [DataContract]
    [KnownType(typeof(AmmoInventoryItemData))]
    // [JsonConverter(typeof(InventoryItemDataConverter))]
    public class AmmoInventoryItemData : FilledInventoryItemData
    {
        // [DataMember]
        public AmmoId Id;

        public AmmoInventoryItemData()
        {
        }

        public AmmoInventoryItemData(int count, AmmoId id) : base(count, InventoryItemId.Ammo)
        {
            Id = id;
        }
    }
}