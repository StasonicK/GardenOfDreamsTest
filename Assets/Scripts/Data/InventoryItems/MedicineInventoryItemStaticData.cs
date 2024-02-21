using Data.InventoryItems.Ids;
using UnityEngine;

namespace Data.InventoryItems
{
    [CreateAssetMenu(fileName = "Medicine", menuName = "StaticData/Medicine")]
    public class MedicineInventoryItemStaticData : ScriptableObject
    {
        public MedicineId Id;
        public string Name;
        public Sprite Icon;
        public float Weight;
        public int Count;
        public int MaxStackCount;
        public float HealValue;
    }
}