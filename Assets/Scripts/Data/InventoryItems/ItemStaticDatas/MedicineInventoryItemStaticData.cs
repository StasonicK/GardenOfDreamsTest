using Data.InventoryItems.Ids;
using UnityEngine;

namespace Data.InventoryItems.ItemStaticDatas
{
    [CreateAssetMenu(fileName = "Medicine", menuName = "StaticData/Medicine")]
    public class MedicineInventoryItemStaticData : ScriptableObject
    {
        public MedicineId Id;
        public string Name;
        public Sprite MainIcon;
        public float Weight;
        public int Count;
        public int MaxStackCount;
        public float HealValue;
        public Sprite TraitIcon;
    }
}