using Data.InventoryItems.Ids;
using UnityEngine;

namespace Data.InventoryItems
{
    [CreateAssetMenu(fileName = "BodyArmor", menuName = "StaticData/BodyArmor")]
    public class BodyArmorInventoryItemStaticData : ScriptableObject
    {
        public BodyArmorId Id;
        public string Name;
        public Sprite Icon;
        public float Weight;
        public int Count;
        public int MaxStackCount;
        public float DefenseValue;
    }
}