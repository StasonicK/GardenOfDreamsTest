using Data.InventoryItems.Ids;
using UI.Screens.Main.ItemViews;
using UI.Windows;
using UnityEngine;

namespace UI.Screens.Main
{
    public class InventoryItemCell : MonoBehaviour
    {
        [SerializeField] private EmptyInventoryItemView _inventoryItemView;
        [SerializeField] private AmmoInventoryItemView _ammoInventoryItemView;
        [SerializeField] private HeadgearInventoryItemView _headgearInventoryItemView;
        [SerializeField] private OuterwearInventoryItemView _outerwearInventoryItemView;
        [SerializeField] private MedicineInventoryItemView _medicineInventoryItemView;

        public void ShowEmptyInventoryItem() =>
            Show(InventoryItemId.Empty);

        public void ShowAmmoInventoryItem(string title, Sprite mainIcon, int count, int maxStackCount, float weight,
            Sprite traitIcon, InventoryItemWindow inventoryItemWindow)
        {
            _ammoInventoryItemView.Construct(title, mainIcon, count, maxStackCount, weight, traitIcon,
                inventoryItemWindow);
            Show(InventoryItemId.Ammo);
        }

        public void ShowHeadgearInventoryItem(string title, Sprite mainIcon, int count, int maxStackCount, float weight,
            float defenseValue, Sprite traitIcon, InventoryItemWindow inventoryItemWindow)
        {
            _headgearInventoryItemView.Construct(title, mainIcon, count, maxStackCount, weight, defenseValue, traitIcon,
                inventoryItemWindow);
            Show(InventoryItemId.Headgear);
        }

        public void ShowOuterwearInventoryItem(string title, Sprite mainIcon, int count, int maxStackCount,
            float weight, float defenseValue, Sprite traitIcon, InventoryItemWindow inventoryItemWindow)
        {
            _outerwearInventoryItemView.Construct(title, mainIcon, count, maxStackCount, weight, defenseValue,
                traitIcon, inventoryItemWindow);
            Show(InventoryItemId.Outerwear);
        }

        public void ShowMedicineInventoryItem(string title, Sprite mainIcon, int count, int maxStackCount, float weight,
            float healValue, Sprite traitIcon, InventoryItemWindow inventoryItemWindow)
        {
            _medicineInventoryItemView.Construct(title, mainIcon, count, maxStackCount, weight, healValue, traitIcon,
                inventoryItemWindow);
            Show(InventoryItemId.Medicine);
        }

        private void Show(InventoryItemId inventoryItemId)
        {
            switch (inventoryItemId)
            {
                case InventoryItemId.Empty:
                    _inventoryItemView.gameObject.SetActive(true);
                    _ammoInventoryItemView.gameObject.SetActive(false);
                    _headgearInventoryItemView.gameObject.SetActive(false);
                    _outerwearInventoryItemView.gameObject.SetActive(false);
                    _medicineInventoryItemView.gameObject.SetActive(false);
                    break;
                case InventoryItemId.Ammo:
                    _ammoInventoryItemView.gameObject.SetActive(true);
                    _inventoryItemView.gameObject.SetActive(false);
                    _headgearInventoryItemView.gameObject.SetActive(false);
                    _outerwearInventoryItemView.gameObject.SetActive(false);
                    _medicineInventoryItemView.gameObject.SetActive(false);
                    break;
                case InventoryItemId.Headgear:
                    _headgearInventoryItemView.gameObject.SetActive(true);
                    _inventoryItemView.gameObject.SetActive(false);
                    _ammoInventoryItemView.gameObject.SetActive(false);
                    _outerwearInventoryItemView.gameObject.SetActive(false);
                    _medicineInventoryItemView.gameObject.SetActive(false);
                    break;
                case InventoryItemId.Outerwear:
                    _outerwearInventoryItemView.gameObject.SetActive(true);
                    _inventoryItemView.gameObject.SetActive(false);
                    _ammoInventoryItemView.gameObject.SetActive(false);
                    _headgearInventoryItemView.gameObject.SetActive(false);
                    _medicineInventoryItemView.gameObject.SetActive(false);
                    break;
                case InventoryItemId.Medicine:
                    _medicineInventoryItemView.gameObject.SetActive(true);
                    _inventoryItemView.gameObject.SetActive(false);
                    _ammoInventoryItemView.gameObject.SetActive(false);
                    _headgearInventoryItemView.gameObject.SetActive(false);
                    _outerwearInventoryItemView.gameObject.SetActive(false);
                    break;
            }
        }
    }
}