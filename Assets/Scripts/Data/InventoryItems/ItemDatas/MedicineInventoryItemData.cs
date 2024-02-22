using System;
using Data.InventoryItems.Ids;
using JetBrains.Annotations;
using UnityEngine;

namespace Data.InventoryItems.ItemDatas
{
    [Serializable]
    public class MedicineInventoryItemData : InventoryItemData
    {
        public MedicineId Id;
        public float HealValue;

        public MedicineInventoryItemData([CanBeNull] Sprite mainIcon, int count, int maxStackCount,
            float weight, InventoryItemId inventoryItemId, MedicineId id, float healValue, Sprite traitIcon)
            : base(count, maxStackCount, weight, inventoryItemId, mainIcon, traitIcon)
        {
            Id = id;
            HealValue = healValue;
        }
    }
}