using System.Runtime.Serialization;
using Data.InventoryItems.Ids;

namespace Data.InventoryItems.ItemDatas
{
    [KnownType(typeof(OuterwearInventoryItemData))]
    public class OuterwearInventoryItemData : FilledInventoryItemData
    {
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