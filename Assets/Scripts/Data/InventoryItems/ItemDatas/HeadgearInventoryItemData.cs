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
        public float DefenseValue;

        public HeadgearInventoryItemData([CanBeNull] Sprite mainIcon, int count, int maxStackCount,
            float weight, InventoryItemId inventoryItemId, HeadgearId id, float defenseValue, Sprite traitIcon)
            : base(count, maxStackCount, weight, inventoryItemId, mainIcon, traitIcon)
        {
            Id = id;
            DefenseValue = defenseValue;
        }
    }
}