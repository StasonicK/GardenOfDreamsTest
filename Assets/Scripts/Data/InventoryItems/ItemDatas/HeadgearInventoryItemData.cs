using System.Runtime.Serialization;
using Data.InventoryItems.Ids;

namespace Data.InventoryItems.ItemDatas
{
    [KnownType(typeof(HeadgearInventoryItemData))]
    public class HeadgearInventoryItemData : FilledInventoryItemData
    {
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