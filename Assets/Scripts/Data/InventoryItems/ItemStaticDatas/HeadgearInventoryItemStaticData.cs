using Data.InventoryItems.Ids;
using UnityEngine;

namespace Data.InventoryItems.ItemStaticDatas
{
    [CreateAssetMenu(fileName = "HeadArmor", menuName = "StaticData/HeadArmor")]
    public class HeadgearInventoryItemStaticData : ScriptableObject
    {
        public HeadgearId Id;
        public string Name;
        public Sprite MainIcon;
        public float Weight;
        public int Count;
        public int MaxStackCount;
        public float DefenseValue;
        public Sprite TraitIcon;
    }
}