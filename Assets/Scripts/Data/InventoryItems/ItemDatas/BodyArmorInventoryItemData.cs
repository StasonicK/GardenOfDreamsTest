using System;
using Data.InventoryItems.Ids;
using JetBrains.Annotations;
using UnityEngine;

namespace Data.InventoryItems.ItemDatas
{
    [Serializable]
    public class BodyArmorInventoryItemData : InventoryItemData
    {
        public BodyArmorId Id;
        public float DefenseValue;

        public BodyArmorInventoryItemData([CanBeNull] Sprite mainIcon, int count, int maxStackCount,
            float weight, InventoryItemId inventoryItemId, BodyArmorId id, float defenseValue, Sprite traitIcon)
            : base(count, maxStackCount, weight, inventoryItemId, true, mainIcon, traitIcon)
        {
            Id = id;
            DefenseValue = defenseValue;
        }
    }
}