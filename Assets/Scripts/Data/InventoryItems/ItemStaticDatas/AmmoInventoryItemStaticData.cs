using Data.InventoryItems.Ids;
using UnityEngine;

namespace Data.InventoryItems.ItemStaticDatas
{
    [CreateAssetMenu(fileName = "Ammo", menuName = "StaticData/Ammo")]
    public class AmmoInventoryItemStaticData : ScriptableObject
    {
        public AmmoId Id;
        public string Name;
        public Sprite MainIcon;
        public float Weight;
        public int Count;
        public int MaxStackCount;
        public Sprite TraitIcon;
    }
}