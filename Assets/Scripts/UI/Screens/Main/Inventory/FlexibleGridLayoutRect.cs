using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens.Main.Inventory
{
    public class FlexibleGridLayoutRect : MonoBehaviour
    {
        [SerializeField] private GameObject _container;
        [SerializeField] private float _verticalOffset;
        [SerializeField] private float _horizontalOffset;

        private RectTransform _rectTransform;
        private GridLayoutGroup _gridLayoutGroup;
        private Vector2 _newSize;

        public void FitCells(int columnsCount, int rowsCount)
        {
            _rectTransform = _container.GetComponent<RectTransform>();
            _gridLayoutGroup = _container.GetComponent<GridLayoutGroup>();
            float rectWidth = _rectTransform.rect.width;
            float rectHeight = _rectTransform.rect.height;
            float horizontalCellSize = rectWidth / columnsCount - _horizontalOffset;
            float verticalCellSize = rectHeight / rowsCount - _verticalOffset;
            float cellSize = Math.Min(horizontalCellSize, verticalCellSize);
            _newSize = new Vector2(cellSize, cellSize);
            _gridLayoutGroup.cellSize = _newSize;
        }
    }
}