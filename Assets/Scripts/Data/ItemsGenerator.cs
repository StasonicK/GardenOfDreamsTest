using System;
using System.Collections.Generic;
using System.Linq;
using Data.InventoryItems.Ids;
using Data.InventoryItems.ItemDatas;
using StaticData.ItemStaticDatas;
using UI.Screens.Main.Inventory;
using UI.Windows;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Data
{
    public class ItemsGenerator : MonoBehaviour
    {
        [SerializeField] private ItemsContainer _container;
        [SerializeField] private InventoryCell _inventoryCellPrefab;
        [SerializeField] private InventoryItem _inventoryItemPrefab;
        [SerializeField] private InventoryItemWindow _inventoryItemWindow;
        [SerializeField] private bool _random;

        private List<InventoryCell> _inventoryCells;
        private InventoryCell _inventoryCell;
        private InventoryItem _inventoryItem;
        private int _itemIndex;
        private int _notEmptyCellsCount;
        private int _rows;
        private int _columns;
        private List<AmmoId> _ammoIds = Enum.GetValues(typeof(AmmoId)).Cast<AmmoId>().ToList();
        private List<OuterwearId> _outerwearIds = Enum.GetValues(typeof(OuterwearId)).Cast<OuterwearId>().ToList();
        private List<HeadgearId> _headgearIds = Enum.GetValues(typeof(HeadgearId)).Cast<HeadgearId>().ToList();
        private List<MedicineId> _medicineIds = Enum.GetValues(typeof(MedicineId)).Cast<MedicineId>().ToList();
        private int _currentAmmoItemsCount = 0;
        private int _currentOuterwearItemsCount = 0;
        private int _currentHeadgearItemsCount = 0;
        private int _currentMedicineItemsCount = 0;
        private Dictionary<int, bool> _allCellsStatus;
        private int _allCellsCount;
        private int _currentNotEmptyCellsCount;
        private AmmoInventoryItemStaticData _ammoInventoryItemStaticData;
        private OuterwearInventoryItemStaticData _outerwearInventoryItemStaticData;
        private HeadgearInventoryItemStaticData _headgearInventoryItemStaticData;
        private MedicineInventoryItemStaticData _medicineInventoryItemStaticData;
        private int _count;
        private AmmoId _ammoId;
        private OuterwearId _outerwearId;
        private HeadgearId _headgearId;
        private MedicineId _medicineId;

        public List<InventoryCell> InventoryCells => _inventoryCells;

        public void Initialize(int notEmptyCellsCount, int rows, int columns)
        {
            _notEmptyCellsCount = notEmptyCellsCount;
            _rows = rows;
            _columns = columns;
            Generate();
        }

        public void InitializeSaved(List<InventoryItemData> inventoryItemDatas)
        {
            _inventoryCells = new List<InventoryCell>();

            foreach (InventoryItemData itemData in inventoryItemDatas)
            {
                _inventoryCell = Instantiate(_inventoryCellPrefab, _container.transform);
                _inventoryItem = Instantiate(_inventoryItemPrefab, _inventoryCell.transform);

                switch (itemData.InventoryItemId)
                {
                    case InventoryItemId.Empty:
                        _inventoryItem.ShowEmptyInventoryItem();
                        break;
                    case InventoryItemId.Ammo:
                        _ammoInventoryItemStaticData =
                            StaticDataManager.Instance.ForAmmo(((AmmoInventoryItemData)itemData).Id);
                        _inventoryItem.ShowAmmoInventoryItem(_ammoInventoryItemStaticData.Name,
                            _ammoInventoryItemStaticData.MainIcon, ((AmmoInventoryItemData)itemData).Count,
                            _ammoInventoryItemStaticData.MaxStackCount, _ammoInventoryItemStaticData.Weight,
                            _ammoInventoryItemStaticData.TraitIcon, _ammoInventoryItemStaticData.Id,
                            _inventoryItemWindow);
                        break;
                    case InventoryItemId.Headgear:
                        _headgearInventoryItemStaticData =
                            StaticDataManager.Instance.ForHeadgear(((HeadgearInventoryItemData)itemData).Id);
                        _inventoryItem.ShowHeadgearInventoryItem(_headgearInventoryItemStaticData.Name,
                            _headgearInventoryItemStaticData.MainIcon, ((HeadgearInventoryItemData)itemData).Count,
                            _headgearInventoryItemStaticData.MaxStackCount, _headgearInventoryItemStaticData.Weight,
                            _headgearInventoryItemStaticData.DefenseValue, _headgearInventoryItemStaticData.TraitIcon,
                            _headgearInventoryItemStaticData.Id,
                            _inventoryItemWindow);
                        break;
                    case InventoryItemId.Outerwear:
                        _outerwearInventoryItemStaticData =
                            StaticDataManager.Instance.ForOuterwear(((OuterwearInventoryItemData)itemData).Id);
                        _inventoryItem.ShowOuterwearInventoryItem(_outerwearInventoryItemStaticData.Name,
                            _outerwearInventoryItemStaticData.MainIcon, ((OuterwearInventoryItemData)itemData).Count,
                            _outerwearInventoryItemStaticData.MaxStackCount, _outerwearInventoryItemStaticData.Weight,
                            _outerwearInventoryItemStaticData.DefenseValue, _outerwearInventoryItemStaticData.TraitIcon,
                            _outerwearInventoryItemStaticData.Id, _inventoryItemWindow);
                        break;
                    case InventoryItemId.Medicine:
                        _medicineInventoryItemStaticData =
                            StaticDataManager.Instance.ForMedicine(((MedicineInventoryItemData)itemData).Id);
                        _inventoryItem.ShowMedicineInventoryItem(_medicineInventoryItemStaticData.Name,
                            _medicineInventoryItemStaticData.MainIcon, ((MedicineInventoryItemData)itemData).Count,
                            _medicineInventoryItemStaticData.MaxStackCount, _medicineInventoryItemStaticData.Weight,
                            _medicineInventoryItemStaticData.Heal, _medicineInventoryItemStaticData.TraitIcon,
                            _medicineInventoryItemStaticData.Id,
                            _inventoryItemWindow);
                        break;
                }
            }

            _inventoryCells.Add(_inventoryCell);
        }

        public void Generate()
        {
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

            if (_inventoryCells != null)
            {
                if (_inventoryCells.Count > 0)
                {
                    foreach (InventoryCell cell in _inventoryCells)
                    {
                        _inventoryCells.Remove(cell);
                        Destroy(cell);
                    }
                }
            }
            else
            {
                _inventoryCells = new List<InventoryCell>(_columns * _rows);
            }

            for (int i = 0; i < _allCellsStatus.Count; i++)
            {
                _inventoryCell = Instantiate(_inventoryCellPrefab, _container.transform);
                _inventoryItem = Instantiate(_inventoryItemPrefab, _inventoryCell.transform);

                if (_allCellsStatus[i])
                    CreateRandomNonEmptyInventoryItem();
                else
                    _inventoryItem.ShowEmptyInventoryItem();

                _inventoryCell.SetInventoryItem(_inventoryItem);
                _inventoryCells.Add(_inventoryCell);
            }
        }

        public void CreateRandomItem()
        {
            int index = GetRandomItemIndex();
            _inventoryCell = _inventoryCells[index];
            _inventoryItem = _inventoryCell.InventoryItem;
            CreateRandomNonEmptyInventoryItem();
            _inventoryCell.SetInventoryItem(_inventoryItem);
        }

        private void CreateRandomNonEmptyInventoryItem()
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

                        _inventoryItem.ShowAmmoInventoryItem(_ammoInventoryItemStaticData.Name,
                            _ammoInventoryItemStaticData.MainIcon, _count, _ammoInventoryItemStaticData.MaxStackCount,
                            _ammoInventoryItemStaticData.Weight,
                            _ammoInventoryItemStaticData.TraitIcon, _ammoInventoryItemStaticData.Id,
                            _inventoryItemWindow);
                    }

                    break;

                case 1:
                    if (_currentAmmoItemsCount <= _currentOuterwearItemsCount ||
                        _currentHeadgearItemsCount <= _currentOuterwearItemsCount ||
                        _currentMedicineItemsCount <= _currentOuterwearItemsCount)
                    {
                        _itemIndex = Random.Range(1, _outerwearIds.Count);
                        _outerwearId = _outerwearIds[_itemIndex];
                        _outerwearInventoryItemStaticData =
                            StaticDataManager.Instance.ForOuterwear(_outerwearId);

                        if (_random)
                            _count = Random.Range(1, _outerwearInventoryItemStaticData.MaxStackCount + 1);
                        else
                            _count = _outerwearInventoryItemStaticData.MaxStackCount;

                        _inventoryItem.ShowOuterwearInventoryItem(_outerwearInventoryItemStaticData.Name,
                            _outerwearInventoryItemStaticData.MainIcon, _count,
                            _outerwearInventoryItemStaticData.MaxStackCount,
                            _outerwearInventoryItemStaticData.Weight,
                            _outerwearInventoryItemStaticData.DefenseValue,
                            _outerwearInventoryItemStaticData.TraitIcon,
                            _outerwearInventoryItemStaticData.Id, _inventoryItemWindow);
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

                        _inventoryItem.ShowHeadgearInventoryItem(_headgearInventoryItemStaticData.Name,
                            _headgearInventoryItemStaticData.MainIcon, _count,
                            _headgearInventoryItemStaticData.MaxStackCount,
                            _headgearInventoryItemStaticData.Weight,
                            _headgearInventoryItemStaticData.DefenseValue,
                            _headgearInventoryItemStaticData.TraitIcon, _headgearInventoryItemStaticData.Id,
                            _inventoryItemWindow);
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

                        _inventoryItem.ShowMedicineInventoryItem(_medicineInventoryItemStaticData.Name,
                            _medicineInventoryItemStaticData.MainIcon, _count,
                            _medicineInventoryItemStaticData.MaxStackCount,
                            _medicineInventoryItemStaticData.Weight,
                            _medicineInventoryItemStaticData.Heal,
                            _medicineInventoryItemStaticData.TraitIcon, _medicineInventoryItemStaticData.Id,
                            _inventoryItemWindow);
                    }

                    break;
            }
        }

        private int GetRandomItemIndex()
        {
            for (int i = 0; i < _inventoryCells.Count; i++)
            {
                if (_inventoryCells[i].InventoryItem.InventoryItemId == InventoryItemId.Empty)
                {
                    _itemIndex = i;
                    break;
                }
            }

            return _itemIndex;
        }
    }
}