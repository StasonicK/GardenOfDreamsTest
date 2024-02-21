using System;
using Data.InventoryItems.Ids;
using JetBrains.Annotations;
using UnityEngine;

namespace Data.InventoryItems.ItemDatas
{
    [Serializable]
    public class HeadArmorInventoryItemData : InventoryItemData
    {
        public HeadArmorId Id;
        public float DefenseValue;

        public HeadArmorInventoryItemData([CanBeNull] Sprite mainIcon, int count, int maxStackCount,
            float weight, InventoryItemId inventoryItemId, HeadArmorId id, float defenseValue, Sprite traitIcon)
            : base(count, maxStackCount, weight, inventoryItemId, true, mainIcon, traitIcon)
        {
            Id = id;
            DefenseValue = defenseValue;
        }
    }
}