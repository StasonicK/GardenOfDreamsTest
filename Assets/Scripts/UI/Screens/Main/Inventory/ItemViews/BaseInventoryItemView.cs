using Data.InventoryItems.Ids;
using TMPro;
using UI.Windows;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens.Main.Inventory.ItemViews
{
    public abstract class BaseInventoryItemView : MonoBehaviour
    {
        [SerializeField] private Image _iconImage;
        [SerializeField] private TextMeshProUGUI _countText;
        [SerializeField] private Button _button;

        public string Title { get; private set; }
        public Sprite MainIcon { get; private set; }
        public int Count { get; private set; }
        public int MaxStackCount { get; private set; }
        public float Weight { get; private set; }
        public Sprite TraitIcon { get; private set; }
        public InventoryItem InventoryItem { get; private set; }
        public InventoryItemWindow InventoryItemWindow { get; private set; }

        private void Awake()
        {
            if (_button != null)
                _button.onClick.AddListener(OnItemButtonClick);
        }

        protected virtual void OnItemButtonClick()
        {
        }

        protected void Construct(string title, Sprite mainIcon, int count, int maxStackCount, float weight,
            Sprite traitIcon, InventoryItem inventoryItem, InventoryItemWindow inventoryItemWindow)
        {
            Title = title;
            MainIcon = mainIcon;
            Count = count;
            MaxStackCount = maxStackCount;
            Weight = weight;
            TraitIcon = traitIcon;
            InventoryItem = inventoryItem;
            InventoryItemWindow = inventoryItemWindow;

            _countText.text = count == 1 ? "" : $"{count}";
            _iconImage.sprite = mainIcon;
        }

        protected void AddCount(int value)
        {
            Count += value;
            ShowCountText();
        }

        protected void RemoveCount(int value)
        {
            Count -= value;
            ShowCountText();
        }

        private void ShowCountText()
        {
            if (InventoryItem.InventoryItemId == InventoryItemId.Medicine)
                _countText.text = Count > 1 ? $"{Count}" : "";
            else
                _countText.text = $"{Count}";
        }

        public void ReduceCount()
        {
            Count--;
            ShowCountText();
        }

        public abstract void TryStack(InventoryItem thisInventoryItem, InventoryItem targetItem);
    }
}