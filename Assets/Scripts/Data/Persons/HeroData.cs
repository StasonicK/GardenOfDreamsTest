using System;
using Data.InventoryItems.Ids;

namespace Data.Persons
{
    [Serializable]
    public class HeroData : PersonData
    {
        public WeaponId WeaponId;
        public HeadgearId HeadgearId;
        public OuterwearId OuterwearId;
        public int AssaultRifleAmmoCount;
        public int PistolAmmoCount;

        public HeroData()
        {
        }

        public HeroData(float maxHealth, float currentHealth) : base(maxHealth, currentHealth)
        {
        }

        public HeroData(float maxHealth, float currentHealth, WeaponId weaponId, HeadgearId headgearId,
            OuterwearId outerwearId, int assaultRifleAmmoCount, int pistolAmmoCount) : base(maxHealth, currentHealth)
        {
            WeaponId = weaponId;
            HeadgearId = headgearId;
            OuterwearId = outerwearId;
            AssaultRifleAmmoCount = assaultRifleAmmoCount;
            PistolAmmoCount = pistolAmmoCount;
        }
    }
}