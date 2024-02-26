using System;
using Data.InventoryItems.Ids;
using JetBrains.Annotations;
using UnityEngine;

namespace Data.InventoryItems.ItemDatas
{
    [Serializable]
    public class HeadgearInventoryItemData : InventoryItemData
    {
        public HeadgearId Id;
        public int DefenseValue;

        public HeadgearInventoryItemData(string name, [CanBeNull] Sprite mainIcon, int count, int maxStackCount,
            float weight, InventoryItemId inventoryItemId, HeadgearId id, int defenseValue, Sprite traitIcon)
            : base(name, count, maxStackCount, weight, inventoryItemId, mainIcon, traitIcon)
        {
            Id = id;
            DefenseValue = defenseValue;
        }
    }
}