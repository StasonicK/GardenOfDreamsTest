using System.Collections.Generic;
using System.Linq;
using Data.InventoryItems.Ids;
using StaticData.ItemStaticDatas;
using StaticData.Weapons;
using UnityEngine;

namespace Data
{
    public class StaticDataManager : MonoBehaviour
    {
        private const string AMMO_INVENTORY_ITEMS_PATH = "StaticData/InventoryItems/Ammo";
        private const string OUTERWEAR_INVENTORY_ITEMS_PATH = "StaticData/InventoryItems/Outerwear";
        private const string HEADGEAR_INVENTORY_ITEMS_PATH = "StaticData/InventoryItems/Headgear";
        private const string MEDICINE_INVENTORY_ITEMS_PATH = "StaticData/InventoryItems/Medicine";
        private const string WEAPONS_PATH = "StaticData/Weapons";

        private static StaticDataManager _instance;

        private Dictionary<AmmoId, AmmoInventoryItemStaticData> _ammoItemStaticDatas;
        private Dictionary<OuterwearId, OuterwearInventoryItemStaticData> _outerwearStaticDatas;
        private Dictionary<HeadgearId, HeadgearInventoryItemStaticData> _headgearStaticDatas;
        private Dictionary<MedicineId, MedicineInventoryItemStaticData> _medicineStaticDatas;
        private Dictionary<WeaponId, WeaponStaticData> _weaponStaticDatas;

        private void Awake() =>
            DontDestroyOnLoad(this);

        private void Initialize()
        {
            _ammoItemStaticDatas = Resources
                .LoadAll<AmmoInventoryItemStaticData>(AMMO_INVENTORY_ITEMS_PATH)
                .ToDictionary(x => x.Id, x => x);

            _outerwearStaticDatas = Resources
                .LoadAll<OuterwearInventoryItemStaticData>(OUTERWEAR_INVENTORY_ITEMS_PATH)
                .ToDictionary(x => x.Id, x => x);

            _headgearStaticDatas = Resources
                .LoadAll<HeadgearInventoryItemStaticData>(HEADGEAR_INVENTORY_ITEMS_PATH)
                .ToDictionary(x => x.Id, x => x);

            _medicineStaticDatas = Resources
                .LoadAll<MedicineInventoryItemStaticData>(MEDICINE_INVENTORY_ITEMS_PATH)
                .ToDictionary(x => x.Id, x => x);

            _weaponStaticDatas = Resources
                .LoadAll<WeaponStaticData>(WEAPONS_PATH)
                .ToDictionary(x => x.Id, x => x);
        }

        public static StaticDataManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<StaticDataManager>();
                    _instance.Initialize();
                }

                return _instance;
            }
        }

        public AmmoInventoryItemStaticData ForAmmo(AmmoId ammoId) =>
            _ammoItemStaticDatas.TryGetValue(ammoId, out AmmoInventoryItemStaticData staticData)
                ? staticData
                : null;

        public HeadgearInventoryItemStaticData ForHeadgear(HeadgearId headgearId) =>
            _headgearStaticDatas.TryGetValue(headgearId, out HeadgearInventoryItemStaticData staticData)
                ? staticData
                : null;

        public OuterwearInventoryItemStaticData ForOuterwear(OuterwearId outerwearId) =>
            _outerwearStaticDatas.TryGetValue(outerwearId, out OuterwearInventoryItemStaticData staticData)
                ? staticData
                : null;

        public MedicineInventoryItemStaticData ForMedicine(MedicineId medicineId) =>
            _medicineStaticDatas.TryGetValue(medicineId, out MedicineInventoryItemStaticData staticData)
                ? staticData
                : null;

        public WeaponStaticData ForWeapon(WeaponId weaponId) =>
            _weaponStaticDatas.TryGetValue(weaponId, out WeaponStaticData staticData)
                ? staticData
                : null;
    }
}