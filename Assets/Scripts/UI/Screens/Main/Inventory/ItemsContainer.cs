using System.Collections.Generic;
using Data;
using Data.InventoryItems.Ids;
using Data.InventoryItems.ItemDatas;
using Logic;
using UnityEngine;

namespace UI.Screens.Main.Inventory
{
    public class ItemsContainer : MonoBehaviour
    {
        [SerializeField] private ItemsGenerator _itemsGenerator;
        [SerializeField] private FlexibleGridLayoutRect _flexibleGridLayoutRect;
        [SerializeField] private int _notEmptyCellsCount = 8;
        [SerializeField] private int _columnsCount = 6;
        [SerializeField] private int _rowsCount = 5;

        private const string FILE_NAME = "ItemsData.dat";

        public int NotEmptyCellsCount => _notEmptyCellsCount;
        public int ColumnsCount => _columnsCount;
        public int RowsCount => _rowsCount;

        private void Awake()
        {
            _flexibleGridLayoutRect.FitCells(_columnsCount, _rowsCount);
            ItemsHolder<InventoryItemData> itemsHolder = new ItemsHolder<InventoryItemData>();

            if (SaveLoadManager.LoadJsonData<ItemsHolder<InventoryItemData>>(FILE_NAME, ref itemsHolder))
            {
                if (itemsHolder == null)
                {
                    _itemsGenerator.Initialize(_notEmptyCellsCount, _rowsCount, _columnsCount);
                    return;
                }

                List<InventoryItemData> inventoryItemDatas = itemsHolder.InventoryItemDatas;

                if (inventoryItemDatas.Count == 0)
                    _itemsGenerator.Initialize(_notEmptyCellsCount, _rowsCount, _columnsCount);
                else
                    _itemsGenerator.InitializeSaved(inventoryItemDatas, _notEmptyCellsCount, _rowsCount, _columnsCount);
            }
            else
            {
                _itemsGenerator.Initialize(_notEmptyCellsCount, _rowsCount, _columnsCount);
            }
        }

        private void OnDestroy()
        {
            ItemsHolder<InventoryItemData> itemsHolder = new ItemsHolder<InventoryItemData>();

            foreach (InventoryCell inventoryCell in _itemsGenerator.InventoryCells)
            {
                switch (inventoryCell.InventoryItemId)
                {
                    case InventoryItemId.Empty:
                        itemsHolder.Add(new EmptyInventoryItemData());
                        break;
                    case InventoryItemId.Ammo:
                        itemsHolder.Add(new AmmoInventoryItemData(
                            inventoryCell.InventoryItem.AmmoInventoryItemView.Count,
                            inventoryCell.InventoryItem.AmmoInventoryItemView.Id));
                        break;
                    case InventoryItemId.Headgear:
                        itemsHolder.Add(new HeadgearInventoryItemData(
                            inventoryCell.InventoryItem.HeadgearInventoryItemView.Count,
                            inventoryCell.InventoryItem.HeadgearInventoryItemView.Id));
                        break;
                    case InventoryItemId.Outerwear:
                        itemsHolder.Add(new OuterwearInventoryItemData(
                            inventoryCell.InventoryItem.OuterwearInventoryItemView.Count,
                            inventoryCell.InventoryItem.OuterwearInventoryItemView.Id));
                        break;
                    case InventoryItemId.Medicine:
                        itemsHolder.Add(new MedicineInventoryItemData(
                            inventoryCell.InventoryItem.MedicineInventoryItemView.Count,
                            inventoryCell.InventoryItem.MedicineInventoryItemView.Id));
                        break;
                }
            }

            SaveLoadManager.SaveJsonData(itemsHolder, FILE_NAME);
        }

        // public void In(){
        //     _itemsGenerator.InitializeSaved(inventoryItemDatas, _notEmptyCellsCount, _rowsCount, _columnsCount);}
    }
}