using System;
using Data.InventoryItems.Ids;
using JetBrains.Annotations;
using UnityEngine;

namespace Data.InventoryItems.ItemDatas
{
    [Serializable]
    public class InventoryItemData
    {
        public string Name;
        [CanBeNull] public Sprite MainIcon;
        public int Count;
        public float Weight;
        public int MaxStackCount;
        public InventoryItemId InventoryItemId;
        [CanBeNull] public Sprite TraitIcon;

        public InventoryItemData(string name, int count, int maxStackCount, float weight,
            InventoryItemId inventoryItemId, [CanBeNull] Sprite mainIcon = null, [CanBeNull] Sprite traitIcon = null)
        {
            Name = name;
            MainIcon = mainIcon;
            Count = count;
            MaxStackCount = maxStackCount;
            Weight = weight;
            InventoryItemId = inventoryItemId;
            TraitIcon = traitIcon;
        }
    }
}