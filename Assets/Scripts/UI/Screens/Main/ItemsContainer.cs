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
        [SerializeField] private AmmoInventoryItemView _ammoInventoryItemViewPrefab;
        [SerializeField] private BodyArmorInventoryItemView _bodyArmorInventoryItemViewPrefab;
        [SerializeField] private HeadArmorInventoryItemView _headArmorInventoryItemViewPrefab;
        [SerializeField] private MedicineInventoryItemView _medicineInventoryItemViewPrefab;
        [SerializeField] private GameObject _emptyInventoryItemViewPrefab;
        [SerializeField] private InventoryItemWindow _inventoryItemWindow;
        [SerializeField] private int _notEmptyCellsCount = 8;
        [SerializeField] private int _columnsCount = 6;
        [SerializeField] private int _rowsCount = 5;

        private List<InventoryItemView> _inventoryItems;
        private InventoryItemView _inventoryItemView;
        private AmmoInventoryItemView _ammoInventoryItemView;
        private BodyArmorInventoryItemView _bodyArmorInventoryItemView;
        private HeadArmorInventoryItemView _headArmorInventoryItemView;
        private MedicineInventoryItemView _medicineInventoryItemView;
        private ItemsDataService _itemsDataService;
        private InventoryItemView _itemView;

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
                if (itemData.IsFull)
                {
                    switch (itemData.InventoryItemId)
                    {
                        case InventoryItemId.Ammo:
                            _ammoInventoryItemView = Instantiate(_ammoInventoryItemViewPrefab, _containerTransform);
                            _ammoInventoryItemView.Construct(itemData.Name, itemData.MainIcon, itemData.Count,
                                itemData.MaxStackCount, itemData.Weight, itemData.InventoryItemId, itemData.TraitIcon,
                                _inventoryItemWindow);
                            break;
                        case InventoryItemId.BodyArmor:
                            _bodyArmorInventoryItemView =
                                Instantiate(_bodyArmorInventoryItemViewPrefab, _containerTransform);
                            _bodyArmorInventoryItemView.Construct(itemData.Name, itemData.MainIcon, itemData.Count,
                                itemData.MaxStackCount, itemData.Weight, itemData.InventoryItemId,
                                ((BodyArmorInventoryItemData)itemData).DefenseValue, itemData.TraitIcon,
                                _inventoryItemWindow);
                            break;
                        case InventoryItemId.HeadArmor:
                            _headArmorInventoryItemView =
                                Instantiate(_headArmorInventoryItemViewPrefab, _containerTransform);
                            _headArmorInventoryItemView.Construct(itemData.Name, itemData.MainIcon, itemData.Count,
                                itemData.MaxStackCount, itemData.Weight, itemData.InventoryItemId,
                                ((HeadArmorInventoryItemData)itemData).DefenseValue, itemData.TraitIcon,
                                _inventoryItemWindow);
                            break;
                        case InventoryItemId.Medicine:
                            _medicineInventoryItemView =
                                Instantiate(_medicineInventoryItemViewPrefab, _containerTransform);
                            _medicineInventoryItemView.Construct(itemData.Name, itemData.MainIcon, itemData.Count,
                                itemData.MaxStackCount, itemData.Weight, itemData.InventoryItemId,
                                ((MedicineInventoryItemData)itemData).HealValue, itemData.TraitIcon,
                                _inventoryItemWindow);
                            break;
                    }
                }
                else
                {
                    Instantiate(_emptyInventoryItemViewPrefab, _containerTransform);
                }
            }
        }
    }
}