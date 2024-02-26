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
    public class ItemsGenerator : MonoBehaviour
    {
        [SerializeField] private bool _random;

        private static ItemsGenerator _instance;

        private int _notEmptyCellsCount;
        private int _rows;
        private int _columns;
        private List<AmmoId> _ammoIds = Enum.GetValues(typeof(AmmoId)).Cast<AmmoId>().ToList();
        private List<OuterwearId> _outerwearIds = Enum.GetValues(typeof(OuterwearId)).Cast<OuterwearId>().ToList();
        private List<HeadgearId> _headgearIds = Enum.GetValues(typeof(HeadgearId)).Cast<HeadgearId>().ToList();
        private List<MedicineId> _medicineIds = Enum.GetValues(typeof(MedicineId)).Cast<MedicineId>().ToList();
        private InventoryItemData _inventoryItemData;
        private int _currentAmmoItemsCount = 0;
        private int _currentOuterwearItemsCount = 0;
        private int _currentHeadgearItemsCount = 0;
        private int _currentMedicineItemsCount = 0;
        private List<InventoryItemData> _inventoryItemsPerCells;
        private Dictionary<int, bool> _allCellsStatus;
        private int _allCellsCount;
        private int _currentNotEmptyCellsCount = 0;
        private AmmoInventoryItemStaticData _ammoInventoryItemStaticData;
        private OuterwearInventoryItemStaticData _outerwearInventoryItemStaticData;
        private HeadgearInventoryItemStaticData _headgearInventoryItemStaticData;
        private MedicineInventoryItemStaticData _medicineInventoryItemStaticData;
        private int _itemIndex;
        private int _count;
        private AmmoId _ammoId;
        private OuterwearId _outerwearId;
        private HeadgearId _headgearId;
        private MedicineId _medicineId;

        public List<InventoryItemData> InventoryItemsPerCells => _inventoryItemsPerCells;

        public void Initialize(int notEmptyCellsCount, int rows, int columns)
        {
            _notEmptyCellsCount = notEmptyCellsCount;
            _rows = rows;
            _columns = columns;

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
                    _inventoryItemsPerCells.Add(new InventoryItemData("", 0, 0, 0f, InventoryItemId.Empty));
            }
        }

        private void CreateRandomInventoryItemData()
        {
            _itemIndex = Random.Range(0, 4);

            switch (_itemIndex)
            {
                case 0:
                    if (_currentOuterwearItemsCount <= _currentAmmoItemsCount ||
                        _currentHeadgearItemsCount <= _currentAmmoItemsCount ||
                        _currentMedicineItemsCount <= _currentAmmoItemsCount)
                    {
                        _itemIndex = Random.Range(0, _ammoIds.Count);
                        _ammoId = _ammoIds[_itemIndex];
                        _ammoInventoryItemStaticData = StaticDataManager.Instance.ForAmmo(_ammoId);

                        if (_random)
                            _count = Random.Range(1, _ammoInventoryItemStaticData.MaxStackCount + 1);
                        else
                            _count = _ammoInventoryItemStaticData.MaxStackCount;

                        _inventoryItemsPerCells.Add(new AmmoInventoryItemData(_ammoInventoryItemStaticData.Name,
                            _ammoInventoryItemStaticData.MainIcon, _count,
                            _ammoInventoryItemStaticData.MaxStackCount, _ammoInventoryItemStaticData.Weight,
                            InventoryItemId.Ammo, _ammoId, _ammoInventoryItemStaticData.TraitIcon));
                    }

                    break;

                case 1:
                    if (_currentAmmoItemsCount <= _currentOuterwearItemsCount ||
                        _currentHeadgearItemsCount <= _currentOuterwearItemsCount ||
                        _currentMedicineItemsCount <= _currentOuterwearItemsCount)
                    {
                        _itemIndex = Random.Range(1, _outerwearIds.Count);
                        _outerwearId = _outerwearIds[_itemIndex];
                        _outerwearInventoryItemStaticData = StaticDataManager.Instance.ForOuterwear(_outerwearId);

                        if (_random)
                            _count = Random.Range(1, _outerwearInventoryItemStaticData.MaxStackCount + 1);
                        else
                            _count = _outerwearInventoryItemStaticData.MaxStackCount;

                        _inventoryItemsPerCells.Add(new OuterwearInventoryItemData(
                            _outerwearInventoryItemStaticData.Name, _outerwearInventoryItemStaticData.MainIcon, _count,
                            _outerwearInventoryItemStaticData.MaxStackCount, _outerwearInventoryItemStaticData.Weight,
                            InventoryItemId.Outerwear, _outerwearId, _outerwearInventoryItemStaticData.DefenseValue,
                            _outerwearInventoryItemStaticData.TraitIcon));
                    }

                    break;

                case 2:
                    if (_currentAmmoItemsCount <= _currentHeadgearItemsCount ||
                        _currentOuterwearItemsCount <= _currentHeadgearItemsCount ||
                        _currentMedicineItemsCount <= _currentHeadgearItemsCount)
                    {
                        _itemIndex = Random.Range(1, _headgearIds.Count);
                        _headgearId = _headgearIds[_itemIndex];
                        _headgearInventoryItemStaticData = StaticDataManager.Instance.ForHeadgear(_headgearId);

                        if (_random)
                            _count = Random.Range(1, _headgearInventoryItemStaticData.MaxStackCount + 1);
                        else
                            _count = _headgearInventoryItemStaticData.MaxStackCount;

                        _inventoryItemsPerCells.Add(new HeadgearInventoryItemData(_headgearInventoryItemStaticData.Name,
                            _headgearInventoryItemStaticData.MainIcon, _count,
                            _headgearInventoryItemStaticData.MaxStackCount, _headgearInventoryItemStaticData.Weight,
                            InventoryItemId.Headgear, _headgearId, _headgearInventoryItemStaticData.DefenseValue,
                            _headgearInventoryItemStaticData.TraitIcon));
                    }

                    break;

                case 3:
                    if (_currentAmmoItemsCount <= _currentMedicineItemsCount ||
                        _currentHeadgearItemsCount <= _currentMedicineItemsCount ||
                        _currentOuterwearItemsCount <= _currentMedicineItemsCount)
                    {
                        _itemIndex = Random.Range(0, _medicineIds.Count);
                        _medicineId = _medicineIds[_itemIndex];
                        _medicineInventoryItemStaticData = StaticDataManager.Instance.ForMedicine(_medicineId);

                        if (_random)
                            _count = 1;
                        else
                            _count = _medicineInventoryItemStaticData.MaxStackCount;

                        _inventoryItemsPerCells.Add(new MedicineInventoryItemData(
                            _medicineInventoryItemStaticData.Name, _medicineInventoryItemStaticData.MainIcon,
                            _count, _medicineInventoryItemStaticData.MaxStackCount,
                            _medicineInventoryItemStaticData.Weight, InventoryItemId.Medicine,
                            _medicineId, _medicineInventoryItemStaticData.Heal,
                            _medicineInventoryItemStaticData.TraitIcon));
                    }

                    break;
            }
        }
    }
}