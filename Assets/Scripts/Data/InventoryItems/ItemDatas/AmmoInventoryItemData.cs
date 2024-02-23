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

        public AmmoInventoryItemData(string name, [CanBeNull] Sprite mainIcon, int count, int maxStackCount,
            float weight, InventoryItemId inventoryItemId, AmmoId id, Sprite traitIcon)
            : base(name, count, maxStackCount, weight, inventoryItemId, mainIcon, traitIcon)
        {
            Id = id;
        }
    }
}