using Data.InventoryItems.Ids;
using UnityEngine;

namespace StaticData.Weapons
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "StaticData/Weapon")]
    public class WeaponStaticData : ScriptableObject
    {
        public WeaponId Id;
        public int Damage;
    }
}