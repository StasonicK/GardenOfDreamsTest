using System.Collections.Generic;
using Data;
using Data.InventoryItems.Ids;
using Data.InventoryItems.ItemDatas;
using UI.Windows;
using UnityEngine;

namespace UI.Screens.Main.Inventory
{
    public class ItemsContainer : MonoBehaviour
    {
        [SerializeField] private ItemsGenerator _itemsGenerator;
        [SerializeField] private FlexibleGridLayoutRect _flexibleGridLayoutRect;
        [SerializeField] private Transform _containerTransform;
        [SerializeField] private InventoryCell _inventoryCellPrefab;
        [SerializeField] private InventoryItem _inventoryItemPrefab;
        [SerializeField] private InventoryItemWindow _inventoryItemWindow;
        [SerializeField] private int _notEmptyCellsCount = 8;
        [SerializeField] private int _columnsCount = 6;
        [SerializeField] private int _rowsCount = 5;

        private List<InventoryCell> _inventoryCells;
        private InventoryCell _inventoryCell;
        private InventoryItem _inventoryItem;
        private int _itemIndex;
        private InventoryItemData _itemData;

        private void Awake()
        {
            _inventoryCells = new List<InventoryCell>(_columnsCount * _rowsCount);
            Initialize();
        }

        public void Initialize()
        {
            if (_inventoryCells.Count > 0)
            {
                foreach (InventoryCell cell in _inventoryCells)
                {
                    _inventoryCells.Remove(cell);
                    Destroy(cell);
                }
            }

            _itemsGenerator.Initialize(_notEmptyCellsCount, _rowsCount, _columnsCount);
            CreateItems();
            _flexibleGridLayoutRect.FitCells(_columnsCount, _rowsCount);
        }

        private void CreateItems()
        {
            foreach (InventoryItemData itemData in _itemsGenerator.InventoryItemsPerCells)
            {
                _inventoryCell = Instantiate(_inventoryCellPrefab, _containerTransform);
                _inventoryItem = Instantiate(_inventoryItemPrefab, _inventoryCell.transform);
                _inventoryCell.SetInventoryItem(_inventoryItem);

                switch (itemData.InventoryItemId)
                {
                    case InventoryItemId.Empty:
                        _inventoryItem.ShowEmptyInventoryItem();
                        break;
                    case InventoryItemId.Ammo:
                        _inventoryItem.ShowAmmoInventoryItem(itemData.Name, itemData.MainIcon, itemData.Count,
                            itemData.MaxStackCount, itemData.Weight, itemData.TraitIcon,
                            ((AmmoInventoryItemData)itemData).Id, _inventoryItemWindow);
                        break;
                    case InventoryItemId.Outerwear:
                        _inventoryItem.ShowOuterwearInventoryItem(itemData.Name, itemData.MainIcon, itemData.Count,
                            itemData.MaxStackCount, itemData.Weight,
                            ((OuterwearInventoryItemData)itemData).DefenseValue, itemData.TraitIcon,
                            ((OuterwearInventoryItemData)itemData).Id, _inventoryItemWindow);
                        break;
                    case InventoryItemId.Headgear:
                        _inventoryItem.ShowHeadgearInventoryItem(itemData.Name, itemData.MainIcon, itemData.Count,
                            itemData.MaxStackCount, itemData.Weight, ((HeadgearInventoryItemData)itemData).DefenseValue,
                            itemData.TraitIcon, ((HeadgearInventoryItemData)itemData).Id, _inventoryItemWindow);
                        break;
                    case InventoryItemId.Medicine:
                        _inventoryItem.ShowMedicineInventoryItem(itemData.Name, itemData.MainIcon, itemData.Count,
                            itemData.MaxStackCount, itemData.Weight, ((MedicineInventoryItemData)itemData).Heal,
                            itemData.TraitIcon, ((MedicineInventoryItemData)itemData).Id, _inventoryItemWindow);
                        break;
                }

                _inventoryCells.Add(_inventoryCell);
            }
        }

        public void CreateRandomItem()
        {
            int index = _itemsGenerator.GetRandomItemIndex();
            _itemData = _itemsGenerator.InventoryItemsPerCells[_itemIndex];
            _inventoryItem = _inventoryCells[index].InventoryItem;

            switch (_itemData.InventoryItemId)
            {
                case InventoryItemId.Empty:
                case InventoryItemId.Ammo:
                    _inventoryItem.ShowAmmoInventoryItem(_itemData.Name, _itemData.MainIcon, _itemData.Count,
                        _itemData.MaxStackCount, _itemData.Weight, _itemData.TraitIcon,
                        ((AmmoInventoryItemData)_itemData).Id, _inventoryItemWindow);
                    break;
                case InventoryItemId.Outerwear:
                    _inventoryItem.ShowOuterwearInventoryItem(_itemData.Name, _itemData.MainIcon, _itemData.Count,
                        _itemData.MaxStackCount, _itemData.Weight,
                        ((OuterwearInventoryItemData)_itemData).DefenseValue, _itemData.TraitIcon,
                        ((OuterwearInventoryItemData)_itemData).Id, _inventoryItemWindow);
                    break;
                case InventoryItemId.Headgear:
                    _inventoryItem.ShowHeadgearInventoryItem(_itemData.Name, _itemData.MainIcon, _itemData.Count,
                        _itemData.MaxStackCount, _itemData.Weight, ((HeadgearInventoryItemData)_itemData).DefenseValue,
                        _itemData.TraitIcon, ((HeadgearInventoryItemData)_itemData).Id, _inventoryItemWindow);
                    break;
                case InventoryItemId.Medicine:
                    _inventoryItem.ShowMedicineInventoryItem(_itemData.Name, _itemData.MainIcon, _itemData.Count,
                        _itemData.MaxStackCount, _itemData.Weight, ((MedicineInventoryItemData)_itemData).Heal,
                        _itemData.TraitIcon, ((MedicineInventoryItemData)_itemData).Id, _inventoryItemWindow);
                    break;
            }
        }
    }
}