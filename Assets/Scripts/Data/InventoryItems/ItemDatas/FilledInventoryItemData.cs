using System.Runtime.Serialization;
using Data.InventoryItems.Ids;

namespace Data.InventoryItems.ItemDatas
{
    [DataContract]
    // [JsonConverter(typeof(InventoryItemDataConverter))]
    public class FilledInventoryItemData : InventoryItemData
    {
        // [DataMember]
        public int Count;

        public FilledInventoryItemData()
        {
        }

        public FilledInventoryItemData(int count, InventoryItemId inventoryItemId) : base(inventoryItemId)
        {
            Count = count;
        }
    }
}