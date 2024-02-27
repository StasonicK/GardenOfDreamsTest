using Data;
using Data.InventoryItems.Ids;
using Data.Persons;
using StaticData.Weapons;
using UnityEngine;

namespace Logic
{
    public class HeroAttack : MonoBehaviour
    {
        [SerializeField] private int _pistolShotAmmoCount = 1;
        [SerializeField] private int _assaultRifleShotAmmoCount = 3;

        private WeaponStaticData _weaponStaticData;

        public bool CanAttack()
        {
            switch (HeroDataManager.Instance.WeaponId)
            {
                case WeaponId.Pistol:
                    if (HeroDataManager.Instance.CheckAmmo(_pistolShotAmmoCount))
                    {
                        HeroDataManager.Instance.SpendAmmo(_pistolShotAmmoCount);
                        return true;
                    }

                    break;
                case WeaponId.AssaultRifle:
                    if (HeroDataManager.Instance.CheckAmmo(_assaultRifleShotAmmoCount))
                    {
                        HeroDataManager.Instance.SpendAmmo(_assaultRifleShotAmmoCount);
                        return true;
                    }

                    break;
            }

            return false;
        }

        public void Attack()
        {
            _weaponStaticData = StaticDataManager.Instance.ForWeapon(HeroDataManager.Instance.WeaponId);
            EnemyDataManager.Instance.GetHit(_weaponStaticData.Damage);
        }
    }
}