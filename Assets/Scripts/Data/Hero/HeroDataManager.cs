using System;
using Data.InventoryItems.Ids;
using UnityEngine;

namespace Data.Hero
{
    public class HeroDataManager : MonoBehaviour
    {
        private const float INITIAL_HEALTH = 100f;

        private static HeroDataManager _instance;

        public float Health { private set; get; }
        public WeaponId WeaponId { private set; get; }
        public HeadgearId HeadgearId { private set; get; }
        public OuterwearId OuterwearId { private set; get; }
        public int AssaultRifleAmmoCount { private set; get; }
        public int PistolAmmoCount { private set; get; }

        public event Action HealthChanged;
        public event Action WeaponChanged;
        public event Action HeadgearChanged;
        public event Action OuterwearChanged;
        public event Action AssaultRifleAmmoChanged;
        public event Action PistolAmmoChanged;

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

        private void Initialize()
        {
            Health = INITIAL_HEALTH;
            WeaponId = WeaponId.Pistol;
            HeadgearId = HeadgearId.None;
            OuterwearId = OuterwearId.None;
            AssaultRifleAmmoCount = 0;
            PistolAmmoCount = 0;
            HealthChanged?.Invoke();
            HeadgearChanged?.Invoke();
            OuterwearChanged?.Invoke();
            PistolAmmoChanged?.Invoke();
            AssaultRifleAmmoChanged?.Invoke();
        }

        public bool CheckNeedHeal() =>
            Health < INITIAL_HEALTH;

        public void Heal(int count)
        {
            Health += count;

            if (Health > INITIAL_HEALTH)
                Health = INITIAL_HEALTH;

            HealthChanged?.Invoke();
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

        public void AddPistolAmmo(int count)
        {
            PistolAmmoCount += count;
            PistolAmmoChanged?.Invoke();
        }

        public void AddAssaultRifleAmmo(int count)
        {
            AssaultRifleAmmoCount += count;
            AssaultRifleAmmoChanged?.Invoke();
        }
    }
}