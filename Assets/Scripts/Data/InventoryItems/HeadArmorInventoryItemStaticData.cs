using Data.InventoryItems.Ids;
using UnityEngine;

namespace Data.InventoryItems
{
    [CreateAssetMenu(fileName = "HeadArmor", menuName = "StaticData/HeadArmor")]
    public class HeadArmorInventoryItemStaticData : ScriptableObject
    {
        public HeadArmorId Id;
        public string Name;
        public Sprite Icon;
        public float Weight;
        public int Count;
        public int MaxStackCount;
        public float DefenseValue;
    }
}