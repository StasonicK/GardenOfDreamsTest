using Data;
using Data.Persons;
using StaticData.Weapons;
using UnityEngine;

namespace Logic
{
    public class HeroAttack : MonoBehaviour
    {
        [SerializeField] private int _shotAmmoCount = 1;

        private WeaponStaticData _weaponStaticData;

        public bool CanAttack()
        {
            if (HeroDataManager.Instance.CheckAmmo(_shotAmmoCount))
            {
                HeroDataManager.Instance.SpendAmmo(_shotAmmoCount);
                return true;
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