using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Data.InventoryItems
{
    [Serializable]
    public struct InventoryItemData
    {
        public bool IsFull;
        [CanBeNull] public Sprite Icon;
        public int Count;
        public float Weight;

        public InventoryItemData(bool isFull, [CanBeNull] Sprite icon, int count, float weight)
        {
            IsFull = isFull;
            Icon = icon;
            Count = count;
            Weight = weight;
        }
    }
}