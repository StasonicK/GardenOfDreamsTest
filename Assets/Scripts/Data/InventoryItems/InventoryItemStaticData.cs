using Data.InventoryItems.Ids;
using UnityEngine;
using UnityEngine.Serialization;

namespace Data.InventoryItems
{
    [CreateAssetMenu(fileName = "InventoryItemData", menuName = "StaticData/InventoryItem")]
    public class InventoryItemStaticData : ScriptableObject
    {
        public InventoryItemId InventoryItemId;
        public AmmoId AmmoId;
        [FormerlySerializedAs("ArmorId")] public BodyArmorId BodyArmorId;
        [FormerlySerializedAs("HatId")] public HeadArmorId headArmorId;
        public MedicineId MedicineId;
        public Sprite Icon;
        public float Weight;
    }
}