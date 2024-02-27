using Data;
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

        private void Awake()
        {
            _itemsGenerator.Initialize(_notEmptyCellsCount, _rowsCount, _columnsCount);
            _flexibleGridLayoutRect.FitCells(_columnsCount, _rowsCount);
        }
    }
}