using System;
using Data.InventoryItems.Ids;

namespace Data.Persons
{
    public class HeroDataManager : BaseDataManager
    {
        private static HeroDataManager _instance;
        public WeaponId WeaponId { private set; get; }
        public HeadgearId HeadgearId { private set; get; }
        public OuterwearId OuterwearId { private set; get; }
        public int AssaultRifleAmmoCount { private set; get; }
        public int PistolAmmoCount { private set; get; }

        public event Action WeaponChanged;
        public event Action HeadgearChanged;
        public event Action OuterwearChanged;
        public event Action AssaultRifleAmmoChanged;
        public event Action PistolAmmoChanged;
        public event Action Died;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            Instance.Initialize();
        }

        public static HeroDataManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<HeroDataManager>();

                return _instance;
            }
        }

        public override void Initialize()
        {
            base.Initialize();
            WeaponId = WeaponId.Pistol;
            HeadgearId = HeadgearId.None;
            OuterwearId = OuterwearId.None;
            AssaultRifleAmmoCount = 0;
            PistolAmmoCount = 0;
            WeaponChanged?.Invoke();
            HeadgearChanged?.Invoke();
            OuterwearChanged?.Invoke();
            PistolAmmoChanged?.Invoke();
            AssaultRifleAmmoChanged?.Invoke();
        }

        public void ChangeWeapon(WeaponId weaponId)
        {
            WeaponId = weaponId;
            WeaponChanged?.Invoke();
        }

        public bool CanChangeHeadgear(HeadgearId headgearId) =>
            HeadgearId != headgearId;

        public void ChangeHeadgear(HeadgearId headgearId)
        {
            HeadgearId = headgearId;
            HeadgearChanged?.Invoke();
        }

        public bool CanChangeOuterwear(OuterwearId outerwearId) =>
            OuterwearId != outerwearId;

        public void ChangeOuterwear(OuterwearId outerwearId)
        {
            OuterwearId = outerwearId;
            OuterwearChanged?.Invoke();
        }

        public bool CheckAmmo(int spendCount)
        {
            switch (WeaponId)
            {
                case WeaponId.Pistol:
                    if (PistolAmmoCount > 0 && PistolAmmoCount >= spendCount)
                        return true;
                    break;
                case WeaponId.AssaultRifle:
                    if (AssaultRifleAmmoCount > 0 && AssaultRifleAmmoCount >= spendCount)
                        return true;
                    break;
            }

            return false;
        }

        public void AddAmmo(WeaponId id, int count)
        {
            switch (id)
            {
                case WeaponId.Pistol:
                    PistolAmmoCount += count;
                    PistolAmmoChanged?.Invoke();
                    break;
                case WeaponId.AssaultRifle:
                    AssaultRifleAmmoCount += count;
                    AssaultRifleAmmoChanged?.Invoke();
                    break;
            }
        }

        public void SpendAmmo(int count)
        {
            switch (WeaponId)
            {
                case WeaponId.Pistol:
                    PistolAmmoCount -= count;
                    PistolAmmoChanged?.Invoke();
                    break;
                case WeaponId.AssaultRifle:
                    AssaultRifleAmmoCount -= count;
                    AssaultRifleAmmoChanged?.Invoke();
                    break;
            }
        }

        protected override void InvokeDeath()
        {
            Died?.Invoke();
        }
    }
}