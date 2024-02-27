using Data.InventoryItems.Ids;
using UnityEngine;

namespace StaticData.ItemStaticDatas
{
    [CreateAssetMenu(fileName = "HeadArmor", menuName = "StaticData/InventoryItem/HeadArmor")]
    public class HeadgearInventoryItemStaticData : ScriptableObject
    {
        public HeadgearId Id;
        public string Name;
        public Sprite MainIcon;
        public float Weight;
        public int Count;
        public int MaxStackCount;
        public int DefenseValue;
        public Sprite TraitIcon;
    }
}