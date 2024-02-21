using System.Collections.Generic;
using Data;
using Data.InventoryItems;
using UnityEngine;

namespace UI
{
    public class ItemsContainerView : MonoBehaviour
    {
        [SerializeField] private FlexibleGridLayoutRect _flexibleGridLayoutRect;
        [SerializeField] private Transform _containerTransform;
        [SerializeField] private InventoryItemView _inventoryItemViewPrefab;
        [SerializeField] private int _notEmptyCellsCount = 8;
        [SerializeField] private int _columnsCount = 6;
        [SerializeField] private int _rowsCount = 5;

        private List<InventoryItemView> _inventoryItems;
        private InventoryItemView _inventoryItemView;
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
                _itemView = Instantiate(_inventoryItemViewPrefab, _containerTransform);

                if (itemData.IsFull)
                    _itemView.ConstructFull(itemData.Icon, itemData.Count, itemData.Weight);
                else
                    _itemView.ConstructEmpty();
            }
        }
    }
}