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
        [SerializeField] private AmmoItemView _ammoItemViewPrefab;
        [SerializeField] private BodyArmorItemView _bodyArmorItemViewPrefab;
        [SerializeField] private HeadArmorItemView _headArmorItemViewPrefab;
        [SerializeField] private MedicineItemView _medicineItemViewPrefab;
        [SerializeField] private GameObject _emptyInventoryItemViewPrefab;
        [SerializeField] private InventoryItemWindow _inventoryItemWindow;
        [SerializeField] private int _notEmptyCellsCount = 8;
        [SerializeField] private int _columnsCount = 6;
        [SerializeField] private int _rowsCount = 5;

        private List<InventoryItemView> _inventoryItems;
        private InventoryItemView _inventoryItemView;
        private AmmoItemView _ammoItemView;
        private BodyArmorItemView _bodyArmorItemView;
        private HeadArmorItemView _headArmorItemView;
        private MedicineItemView _medicineItemView;
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
                            _ammoItemView = Instantiate(_ammoItemViewPrefab, _containerTransform);
                            _ammoItemView.Construct(itemData.Name, itemData.MainIcon, itemData.Count,
                                itemData.MaxStackCount, itemData.Weight, itemData.InventoryItemId, itemData.TraitIcon,
                                _inventoryItemWindow);
                            break;
                        case InventoryItemId.BodyArmor:
                            _bodyArmorItemView = Instantiate(_bodyArmorItemViewPrefab, _containerTransform);
                            _bodyArmorItemView.Construct(itemData.Name, itemData.MainIcon, itemData.Count,
                                itemData.MaxStackCount, itemData.Weight, itemData.InventoryItemId,
                                ((BodyArmorInventoryItemData)itemData).DefenseValue, itemData.TraitIcon,
                                _inventoryItemWindow);
                            break;
                        case InventoryItemId.HeadArmor:
                            _headArmorItemView = Instantiate(_headArmorItemViewPrefab, _containerTransform);
                            _headArmorItemView.Construct(itemData.Name, itemData.MainIcon, itemData.Count,
                                itemData.MaxStackCount, itemData.Weight, itemData.InventoryItemId,
                                ((HeadArmorInventoryItemData)itemData).DefenseValue, itemData.TraitIcon,
                                _inventoryItemWindow);
                            break;
                        case InventoryItemId.Medicine:
                            _medicineItemView = Instantiate(_medicineItemViewPrefab, _containerTransform);
                            _medicineItemView.Construct(itemData.Name, itemData.MainIcon, itemData.Count,
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