using System.Runtime.Serialization;
using Data.InventoryItems.Ids;

namespace Data.InventoryItems.ItemDatas
{
    // [DataContract]
    [KnownType(typeof(MedicineInventoryItemData))]
    // [JsonConverter(typeof(InventoryItemDataConverter))]
    public class MedicineInventoryItemData : FilledInventoryItemData
    {
        // [DataMember] 
        public MedicineId Id;

        public MedicineInventoryItemData()
        {
        }

        public MedicineInventoryItemData(int count, MedicineId id) : base(count, InventoryItemId.Medicine)
        {
            Id = id;
        }
    }
}