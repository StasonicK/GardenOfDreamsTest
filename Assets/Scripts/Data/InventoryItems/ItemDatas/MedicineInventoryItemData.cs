using System.Runtime.Serialization;
using Data.InventoryItems.Ids;

namespace Data.InventoryItems.ItemDatas
{
    [KnownType(typeof(MedicineInventoryItemData))]
    public class MedicineInventoryItemData : FilledInventoryItemData
    {
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