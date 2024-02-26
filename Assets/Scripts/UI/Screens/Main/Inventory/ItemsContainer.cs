using System.Collections.Generic;
using Data;
using Data.InventoryItems.Ids;
using Data.InventoryItems.ItemDatas;
using UI.Screens.Main.Inventory.ItemViews;
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

        private List<BaseInventoryItemView> _inventoryItems;
        private InventoryCell _inventoryCell;
        private InventoryItem _inventoryItem;

        private void Awake()
        {
            _itemsGenerator.Initialize(_notEmptyCellsCount, _rowsCount, _columnsCount);
            CreateViews();
            _flexibleGridLayoutRect.FitCells(_columnsCount, _rowsCount);
        }

        private void CreateViews()
        {
            foreach (InventoryItemData itemData in _itemsGenerator.InventoryItemsPerCells)
            {
                _inventoryCell = Instantiate(_inventoryCellPrefab, _containerTransform);
                _inventoryItem = Instantiate(_inventoryItemPrefab, _inventoryCell.transform);

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
            }
        }
    }
}