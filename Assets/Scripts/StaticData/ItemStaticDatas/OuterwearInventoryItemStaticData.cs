using Data.InventoryItems.Ids;
using UnityEngine;

namespace StaticData.ItemStaticDatas
{
    [CreateAssetMenu(fileName = "BodyArmor", menuName = "StaticData/InventoryItem/BodyArmor")]
    public class OuterwearInventoryItemStaticData : ScriptableObject
    {
        public OuterwearId Id;
        public string Name;
        public Sprite MainIcon;
        public float Weight;
        public int Count;
        public int MaxStackCount;
        public int DefenseValue;
        public Sprite TraitIcon;
    }
}