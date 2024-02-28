using System.Runtime.Serialization;
using Data.InventoryItems.Ids;

namespace Data.InventoryItems.ItemDatas
{
    [KnownType(typeof(AmmoInventoryItemData))]
    public class AmmoInventoryItemData : FilledInventoryItemData
    {
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