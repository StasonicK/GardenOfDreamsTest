﻿using System;
using Data.InventoryItems.Ids;
using JetBrains.Annotations;
using UnityEngine;

namespace Data.InventoryItems.ItemDatas
{
    [Serializable]
    public class OuterwearInventoryItemData : InventoryItemData
    {
        public OuterwearId Id;
        public float DefenseValue;

        public OuterwearInventoryItemData(string name, [CanBeNull] Sprite mainIcon, int count, int maxStackCount,
            float weight, InventoryItemId inventoryItemId, OuterwearId id, float defenseValue, Sprite traitIcon)
            : base(name, count, maxStackCount, weight, inventoryItemId, mainIcon, traitIcon)
        {
            Id = id;
            DefenseValue = defenseValue;
        }
    }
}