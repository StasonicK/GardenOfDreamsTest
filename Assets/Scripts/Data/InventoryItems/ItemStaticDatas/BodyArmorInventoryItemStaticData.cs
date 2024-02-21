using Data.InventoryItems.Ids;
using UnityEngine;

namespace Data.InventoryItems.ItemStaticDatas
{
    [CreateAssetMenu(fileName = "BodyArmor", menuName = "StaticData/BodyArmor")]
    public class BodyArmorInventoryItemStaticData : ScriptableObject
    {
        public BodyArmorId Id;
        public string Name;
        public Sprite MainIcon;
        public float Weight;
        public int Count;
        public int MaxStackCount;
        public float DefenseValue;
        public Sprite TraitIcon;
    }
}