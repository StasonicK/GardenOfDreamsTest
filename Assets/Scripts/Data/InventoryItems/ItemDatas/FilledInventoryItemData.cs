using System.Runtime.Serialization;
using Data.InventoryItems.Ids;

namespace Data.InventoryItems.ItemDatas
{
    [DataContract]
    public class FilledInventoryItemData : InventoryItemData
    {
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