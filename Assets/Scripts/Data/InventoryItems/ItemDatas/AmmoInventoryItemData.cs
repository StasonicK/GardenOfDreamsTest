using System;
using Data.InventoryItems.Ids;
using JetBrains.Annotations;
using UnityEngine;

namespace Data.InventoryItems.ItemDatas
{
    [Serializable]
    public class AmmoInventoryItemData : InventoryItemData
    {
        public AmmoId Id;

        public AmmoInventoryItemData([CanBeNull] Sprite mainIcon, int count, int maxStackCount, float weight,
            InventoryItemId inventoryItemId, AmmoId id, Sprite traitIcon)
            : base(count, maxStackCount, weight, inventoryItemId, true, mainIcon,traitIcon)
        {
            Id = id;
        }
    }
}