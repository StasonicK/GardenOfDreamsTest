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
        public int Heal;

        public MedicineInventoryItemData(string name, [CanBeNull] Sprite mainIcon, int count, int maxStackCount,
            float weight, InventoryItemId inventoryItemId, MedicineId id, int heal, Sprite traitIcon)
            : base(name, count, maxStackCount, weight, inventoryItemId, mainIcon, traitIcon)
        {
            Id = id;
            Heal = heal;
        }
    }
}