using Data.InventoryItems.Ids;
using TMPro;
using UI.Windows;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens.Main.ItemViews
{
    public class InventoryItemView : MonoBehaviour
    {
        [SerializeField] private Image _iconImage;
        [SerializeField] private TextMeshProUGUI _countText;
        [SerializeField] private Button _button;

        protected string Title { get; private set; }
        protected Sprite MainIcon { get; private set; }
        protected int Count { get; private set; }
        protected int MaxStackCount { get; private set; }
        protected float Weight { get; private set; }
        protected InventoryItemId InventoryItemId { get; private set; }
        protected InventoryItemWindow InventoryItemWindow { get; private set; }
        protected Sprite TraitIcon { get; private set; }

        private void Awake()
        {
            _button.onClick.AddListener(OnItemButtonClick);
        }

        protected virtual void OnItemButtonClick()
        {
        }

        protected void Construct(string title, Sprite mainIcon, int count, int maxStackCount, float weight,
            InventoryItemId inventoryItemId, Sprite traitIcon, InventoryItemWindow inventoryItemWindow)
        {
            Title = title;
            MainIcon = mainIcon;
            Count = count;
            MaxStackCount = maxStackCount;
            Weight = weight;
            InventoryItemId = inventoryItemId;
            InventoryItemWindow = inventoryItemWindow;

            _countText.text = count == 1 ? "" : $"{count}";
            TraitIcon = traitIcon;
            _iconImage.sprite = mainIcon;
            _iconImage.gameObject.SetActive(true);
        }
    }
}