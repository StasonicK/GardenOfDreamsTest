using System;
using System.Collections.Generic;
using System.Linq;
using Data.InventoryItems.Ids;
using Data.InventoryItems.ItemDatas;
using Data.InventoryItems.ItemStaticDatas;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Data
{
    public class ItemsDataService
    {
        private const string AMMO_INVENTORY_ITEMS_PATH = "StaticData/InventoryItems/Ammo";
        private const string BODY_ARMOR_INVENTORY_ITEMS_PATH = "StaticData/InventoryItems/BodyArmor";
        private const string HEAD_ARMOR_INVENTORY_ITEMS_PATH = "StaticData/InventoryItems/HeadArmor";
        private const string MEDICINE_INVENTORY_ITEMS_PATH = "StaticData/InventoryItems/Medicine";

        private readonly int _notEmptyCellsCount;
        private readonly int _rows;
        private readonly int _columns;
        private List<AmmoId> _ammoIds = Enum.GetValues(typeof(AmmoId)).Cast<AmmoId>().ToList();
        private List<BodyArmorId> _bodyArmorIds = Enum.GetValues(typeof(BodyArmorId)).Cast<BodyArmorId>().ToList();
        private List<HeadArmorId> _headArmorIds = Enum.GetValues(typeof(HeadArmorId)).Cast<HeadArmorId>().ToList();
        private List<MedicineId> _medicineIds = Enum.GetValues(typeof(MedicineId)).Cast<MedicineId>().ToList();
        private InventoryItemData _inventoryItemData;
        private Dictionary<AmmoId, AmmoInventoryItemStaticData> _ammoItemStaticDatas;
        private Dictionary<BodyArmorId, BodyArmorInventoryItemStaticData> _bodyArmorStaticDatas;
        private Dictionary<HeadArmorId, HeadArmorInventoryItemStaticData> _headArmorStaticDatas;
        private Dictionary<MedicineId, MedicineInventoryItemStaticData> _medicineStaticDatas;
        private int _currentAmmoItemsCount = 0;
        private int _currentBodyArmorItemsCount = 0;
        private int _currentHeadArmorItemsCount = 0;
        private int _currentMedicineItemsCount = 0;
        private List<InventoryItemData> _inventoryItemsPerCells;
        private Dictionary<int, bool> _allCellsStatus;
        private int _allCellsCount;
        private int _currentNotEmptyCellsCount = 0;
        private AmmoInventoryItemStaticData _ammoInventoryItemStaticData;
        private BodyArmorInventoryItemStaticData _bodyArmorInventoryItemStaticData;
        private HeadArmorInventoryItemStaticData _headArmorInventoryItemStaticData;
        private MedicineInventoryItemStaticData _medicineInventoryItemStaticData;
        private int _itemIndex;
        private int _count;
        private AmmoId _ammoId;
        private BodyArmorId _bodyArmorId;
        private HeadArmorId _headArmorId;
        private MedicineId _medicineId;

        public List<InventoryItemData> InventoryItemsPerCells => _inventoryItemsPerCells;

        public ItemsDataService(int notEmptyCellsCount, int rows, int columns)
        {
            _notEmptyCellsCount = notEmptyCellsCount;
            _rows = rows;
            _columns = columns;


            _ammoItemStaticDatas = Resources
                .LoadAll<AmmoInventoryItemStaticData>(AMMO_INVENTORY_ITEMS_PATH)
                .ToDictionary(x => x.Id, x => x);

            _bodyArmorStaticDatas = Resources
                .LoadAll<BodyArmorInventoryItemStaticData>(BODY_ARMOR_INVENTORY_ITEMS_PATH)
                .ToDictionary(x => x.Id, x => x);

            _headArmorStaticDatas = Resources
                .LoadAll<HeadArmorInventoryItemStaticData>(HEAD_ARMOR_INVENTORY_ITEMS_PATH)
                .ToDictionary(x => x.Id, x => x);

            _medicineStaticDatas = Resources
                .LoadAll<MedicineInventoryItemStaticData>(MEDICINE_INVENTORY_ITEMS_PATH)
                .ToDictionary(x => x.Id, x => x);

            FillAllCells();
            GenerateItems();
        }

        private void FillAllCells()
        {
            int isFull = 0;
            _allCellsCount = _rows * _columns;
            _allCellsStatus = new Dictionary<int, bool>();

            while (_currentNotEmptyCellsCount < _notEmptyCellsCount)
            {
                while (_allCellsStatus.Count < _allCellsCount)
                {
                    if (_currentNotEmptyCellsCount == _notEmptyCellsCount)
                        break;

                    for (int i = 0; i < _allCellsCount; i++)
                    {
                        if (_allCellsStatus.TryGetValue(i, out var status))
                            if (status)
                                continue;

                        if (_currentNotEmptyCellsCount == _notEmptyCellsCount)
                        {
                            _allCellsStatus.Add(i, false);
                            continue;
                        }

                        isFull = Random.Range(0, 2);

                        if (isFull == 1)
                        {
                            _allCellsStatus.Add(i, true);
                            _currentNotEmptyCellsCount++;
                        }
                        else
                        {
                            _allCellsStatus.Add(i, false);
                        }
                    }
                }
            }
        }

        private void GenerateItems()
        {
            if (_notEmptyCellsCount > _rows * _columns)
                return;

            _inventoryItemsPerCells = new List<InventoryItemData>();

            for (int i = 0; i < _allCellsStatus.Count; i++)
            {
                if (_allCellsStatus[i])
                    CreateRandomInventoryItemData();
                else
                    _inventoryItemsPerCells.Add(new InventoryItemData(0, 0, 0f, InventoryItemId.Ammo));
            }
        }

        private void CreateRandomInventoryItemData()
        {
            _itemIndex = Random.Range(0, 4);

            switch (_itemIndex)
            {
                case 0:
                    if (_currentBodyArmorItemsCount <= _currentAmmoItemsCount ||
                        _currentHeadArmorItemsCount <= _currentAmmoItemsCount ||
                        _currentMedicineItemsCount <= _currentAmmoItemsCount)
                    {
                        _itemIndex = Random.Range(0, _ammoIds.Count);
                        _ammoId = _ammoIds[_itemIndex];
                        _ammoInventoryItemStaticData = _ammoItemStaticDatas[_ammoId];
                        _count = Random.Range(1, _ammoInventoryItemStaticData.MaxStackCount + 1);
                        _inventoryItemsPerCells.Add(new AmmoInventoryItemData(_ammoInventoryItemStaticData.MainIcon,
                            _count, _ammoInventoryItemStaticData.MaxStackCount, _ammoInventoryItemStaticData.Weight,
                            InventoryItemId.Ammo, _ammoId, _ammoInventoryItemStaticData.TraitIcon));
                    }

                    break;

                case 1:
                    if (_currentAmmoItemsCount <= _currentBodyArmorItemsCount ||
                        _currentHeadArmorItemsCount <= _currentBodyArmorItemsCount ||
                        _currentMedicineItemsCount <= _currentBodyArmorItemsCount)
                    {
                        _itemIndex = Random.Range(0, _bodyArmorIds.Count);
                        _bodyArmorId = _bodyArmorIds[_itemIndex];
                        _bodyArmorInventoryItemStaticData = _bodyArmorStaticDatas[_bodyArmorId];
                        _count = Random.Range(1, _bodyArmorInventoryItemStaticData.MaxStackCount + 1);
                        _inventoryItemsPerCells.Add(new BodyArmorInventoryItemData(
                            _bodyArmorInventoryItemStaticData.MainIcon, _count,
                            _bodyArmorInventoryItemStaticData.MaxStackCount, _bodyArmorInventoryItemStaticData.Weight,
                            InventoryItemId.BodyArmor, _bodyArmorId, _bodyArmorInventoryItemStaticData.DefenseValue,
                            _bodyArmorInventoryItemStaticData.TraitIcon));
                    }

                    break;

                case 2:
                    if (_currentAmmoItemsCount <= _currentHeadArmorItemsCount ||
                        _currentBodyArmorItemsCount <= _currentHeadArmorItemsCount ||
                        _currentMedicineItemsCount <= _currentHeadArmorItemsCount)
                    {
                        _itemIndex = Random.Range(0, _headArmorIds.Count);
                        _headArmorId = _headArmorIds[_itemIndex];
                        _headArmorInventoryItemStaticData = _headArmorStaticDatas[_headArmorId];
                        _count = Random.Range(1, _headArmorInventoryItemStaticData.MaxStackCount + 1);
                        _inventoryItemsPerCells.Add(new HeadArmorInventoryItemData(
                            _headArmorInventoryItemStaticData.MainIcon, _count,
                            _headArmorInventoryItemStaticData.MaxStackCount, _headArmorInventoryItemStaticData.Weight,
                            InventoryItemId.HeadArmor, _headArmorId, _headArmorInventoryItemStaticData.DefenseValue,
                            _headArmorInventoryItemStaticData.TraitIcon));
                    }

                    break;

                case 3:
                    if (_currentAmmoItemsCount <= _currentMedicineItemsCount ||
                        _currentHeadArmorItemsCount <= _currentMedicineItemsCount ||
                        _currentBodyArmorItemsCount <= _currentMedicineItemsCount)
                    {
                        _itemIndex = Random.Range(0, _medicineIds.Count);
                        _medicineId = _medicineIds[_itemIndex];
                        _medicineInventoryItemStaticData = _medicineStaticDatas[_medicineId];
                        _count = 1;
                        _inventoryItemsPerCells.Add(new MedicineInventoryItemData(
                            _medicineInventoryItemStaticData.MainIcon, _count, 
                            _medicineInventoryItemStaticData.MaxStackCount,
                            _medicineInventoryItemStaticData.Weight, InventoryItemId.Medicine,
                            _medicineId, _medicineInventoryItemStaticData.HealValue,
                            _medicineInventoryItemStaticData.TraitIcon));
                    }

                    break;
            }
        }
    }
}