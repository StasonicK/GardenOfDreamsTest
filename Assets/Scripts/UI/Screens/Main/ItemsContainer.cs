using System.Collections.Generic;
using Data;
using Data.InventoryItems.Ids;
using Data.InventoryItems.ItemDatas;
using UI.Screens.Main.ItemViews;
using UI.Windows;
using UnityEngine;

namespace UI.Screens.Main
{
    public class ItemsContainer : MonoBehaviour
    {
        [SerializeField] private FlexibleGridLayoutRect _flexibleGridLayoutRect;
        [SerializeField] private Transform _containerTransform;
        [SerializeField] private InventoryItemCell _inventoryItemCellPrefab;
        [SerializeField] private InventoryItemWindow _inventoryItemWindow;
        [SerializeField] private int _notEmptyCellsCount = 8;
        [SerializeField] private int _columnsCount = 6;
        [SerializeField] private int _rowsCount = 5;

        private List<BaseInventoryItemView> _inventoryItems;
        private InventoryItemCell _inventoryItemCell;
        private ItemsDataService _itemsDataService;

        private void Awake()
        {
            _itemsDataService = new ItemsDataService(_notEmptyCellsCount, _rowsCount, _columnsCount);
            CreateViews();
            _flexibleGridLayoutRect.FitCells(_columnsCount, _rowsCount);
        }

        private void CreateViews()
        {
            foreach (InventoryItemData itemData in _itemsDataService.InventoryItemsPerCells)
            {
                _inventoryItemCell = Instantiate(_inventoryItemCellPrefab, _containerTransform);

                switch (itemData.InventoryItemId)
                {
                    case InventoryItemId.Empty:
                        _inventoryItemCell.ShowEmptyInventoryItem();
                        break;
                    case InventoryItemId.Ammo:
                        _inventoryItemCell.ShowAmmoInventoryItem(itemData.Name, itemData.MainIcon, itemData.Count,
                            itemData.MaxStackCount, itemData.Weight, itemData.TraitIcon, _inventoryItemWindow);
                        break;
                    case InventoryItemId.Outerwear:
                        _inventoryItemCell.ShowOuterwearInventoryItem(itemData.Name, itemData.MainIcon, itemData.Count,
                            itemData.MaxStackCount, itemData.Weight,
                            ((OuterwearInventoryItemData)itemData).DefenseValue, itemData.TraitIcon,
                            _inventoryItemWindow);
                        break;
                    case InventoryItemId.Headgear:
                        _inventoryItemCell.ShowHeadgearInventoryItem(itemData.Name, itemData.MainIcon, itemData.Count,
                            itemData.MaxStackCount, itemData.Weight, ((HeadgearInventoryItemData)itemData).DefenseValue,
                            itemData.TraitIcon, _inventoryItemWindow);
                        break;
                    case InventoryItemId.Medicine:
                        _inventoryItemCell.ShowMedicineInventoryItem(itemData.Name, itemData.MainIcon, itemData.Count,
                            itemData.MaxStackCount, itemData.Weight, ((MedicineInventoryItemData)itemData).HealValue,
                            itemData.TraitIcon, _inventoryItemWindow);
                        break;
                }
            }
        }
    }
}