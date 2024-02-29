﻿using System;
using Data;
using Data.InventoryItems.Ids;
using Data.Persons;

namespace Logic
{
    public class HeroDataManager : BaseDataManager
    {
        private const string FILE_NAME = "HeroData.dat";
        private const float INITIAL_HEALTH = 100f;

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
        public event Action HealthChanged;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            base.HealthChanged += () => HealthChanged?.Invoke();
            Instance.Initialize();
        }

        private void OnDestroy()
        {
            SaveLoadManager.SaveJsonData(new HeroData(MaxHealth, CurrentHealth, WeaponId, HeadgearId,
                OuterwearId,
                AssaultRifleAmmoCount, PistolAmmoCount), FILE_NAME);
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

        public void Initialize()
        {
            var heroData = new HeroData(MaxHealth, CurrentHealth);

            if (SaveLoadManager.LoadJsonData<HeroData>(FILE_NAME, ref heroData))
            {
                if (heroData.CurrentHealth == 0)
                {
                    GameLoopManager.Instance.Restart();
                    return;
                }

                MaxHealth = heroData.MaxHealth;
                CurrentHealth = heroData.CurrentHealth;
                WeaponId = heroData.WeaponId;
                HeadgearId = heroData.HeadgearId;
                OuterwearId = heroData.OuterwearId;
                AssaultRifleAmmoCount = heroData.AssaultRifleAmmoCount;
                PistolAmmoCount = heroData.PistolAmmoCount;
                HealthChanged?.Invoke();
            }
            else
            {
                base.Initialize(INITIAL_HEALTH);
                WeaponId = WeaponId.Pistol;
                HeadgearId = HeadgearId.None;
                OuterwearId = OuterwearId.None;
                AssaultRifleAmmoCount = 0;
                PistolAmmoCount = 0;
            }

            WeaponChanged?.Invoke();
            HeadgearChanged?.Invoke();
            OuterwearChanged?.Invoke();
            PistolAmmoChanged?.Invoke();
            AssaultRifleAmmoChanged?.Invoke();
        }

        public void InitializeRestart()
        {
            base.Initialize(INITIAL_HEALTH);
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

        protected override void InvokeDeath() =>
            Died?.Invoke();
    }
}