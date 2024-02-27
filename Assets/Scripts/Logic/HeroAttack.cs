using System.Collections;
using Data;
using Data.InventoryItems.Ids;
using Data.Persons;
using StaticData.Weapons;
using UI.Screens.Main.WeaponsPanel;
using UnityEngine;

namespace Logic
{
    public class HeroAttack : MonoBehaviour
    {
        [SerializeField] private EnemyAttack _enemyAttack;
        [SerializeField] private ShootButton _shootButton;
        [SerializeField] private int _pistolShotAmmoCount = 1;
        [SerializeField] private int _assaultRifleShotAmmoCount = 3;
        [SerializeField] private float _delay = 1f;

        private WeaponStaticData _weaponStaticData;
        private WaitForSeconds _waitForSeconds;

        private void Awake() =>
            _waitForSeconds = new WaitForSeconds(_delay);

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

            if (EnemyDataManager.Instance.CurrentHealth > 0)
                StartCoroutine(CoroutineEnemyAttack());
            else
                StartCoroutine(CoroutineEnemyInitialize());
        }

        private IEnumerator CoroutineEnemyAttack()
        {
            yield return _waitForSeconds;
            _enemyAttack.Attack();
            _shootButton.EnableButton();
        }

        private IEnumerator CoroutineEnemyInitialize()
        {
            yield return _waitForSeconds;
            EnemyDataManager.Instance.Initialize();
            _shootButton.EnableButton();
        }
    }
}