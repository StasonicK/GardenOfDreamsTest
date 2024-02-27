using Data;
using Data.InventoryItems.Ids;
using Data.Persons;
using StaticData.ItemStaticDatas;
using TMPro;
using UI.Screens.Main.Inventory;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Windows
{
    public class InventoryItemWindow : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _titleText;
        [SerializeField] private Image _mainIconImage;
        [SerializeField] private Image _traitIconImage;
        [SerializeField] private TextMeshProUGUI _traitValueText;
        [SerializeField] private TextMeshProUGUI _weightValueText;
        [SerializeField] private Button _activateButton;
        [SerializeField] private Button _deleteButton;
        [SerializeField] private Button _closeButton;
        [SerializeField] private TextMeshProUGUI _activateButtonText;

        private InventoryItem _inventoryItem;
        private bool _isActivated;
        private HeadgearId _headgearId;
        private OuterwearId _outerwearId;
        private MedicineId _medicineId;
        private HeadgearInventoryItemStaticData _headgearInventoryItemStaticData;
        private OuterwearInventoryItemStaticData _outerwearInventoryItemStaticData;
        private MedicineInventoryItemStaticData _medicineInventoryItemStaticData;

        private void Awake()
        {
            gameObject.SetActive(false);
            _activateButton.onClick.AddListener(OnActivateButtonClick);
            _deleteButton.onClick.AddListener(OnDeleteButtonClick);
            _closeButton.onClick.AddListener(OnCloseButtonClick);
        }

        private void OnActivateButtonClick()
        {
            if (_isActivated)
                return;

            switch (_inventoryItem.InventoryItemId)
            {
                case InventoryItemId.Ammo:
                    switch (_inventoryItem.AmmoInventoryItemView.Id)
                    {
                        case AmmoId.PistolBullets9x18:
                            HeroDataManager.Instance.AddAmmo(WeaponId.Pistol,
                                _inventoryItem.AmmoInventoryItemView.Count);
                            break;
                        case AmmoId.AssaultRifleBullets545x39:
                            HeroDataManager.Instance.AddAmmo(WeaponId.AssaultRifle,
                                _inventoryItem.AmmoInventoryItemView.Count);
                            break;
                    }

                    _isActivated = true;
                    _inventoryItem.ShowEmptyInventoryItem();
                    break;

                case InventoryItemId.Headgear:
                    if (HeroDataManager.Instance.CanChangeHeadgear(_inventoryItem.HeadgearInventoryItemView.Id))
                    {
                        _headgearId = _inventoryItem.HeadgearInventoryItemView.Id;

                        if (HeroDataManager.Instance.HeadgearId == HeadgearId.None)
                        {
                            _inventoryItem.ShowEmptyInventoryItem();
                        }
                        else
                        {
                            _headgearInventoryItemStaticData = StaticDataManager.Instance.ForHeadgear(_headgearId);
                            _inventoryItem.ShowHeadgearInventoryItem(_headgearInventoryItemStaticData.Name,
                                _headgearInventoryItemStaticData.MainIcon, _headgearInventoryItemStaticData.Count,
                                _headgearInventoryItemStaticData.MaxStackCount, _headgearInventoryItemStaticData.Weight,
                                _headgearInventoryItemStaticData.DefenseValue,
                                _headgearInventoryItemStaticData.TraitIcon, _headgearId, this);
                        }

                        _isActivated = true;
                        HeroDataManager.Instance.ChangeHeadgear(_headgearId);
                    }

                    break;

                case InventoryItemId.Outerwear:
                    if (HeroDataManager.Instance.CanChangeOuterwear(_inventoryItem.OuterwearInventoryItemView.Id))
                    {
                        _outerwearId = _inventoryItem.OuterwearInventoryItemView.Id;

                        if (HeroDataManager.Instance.OuterwearId == OuterwearId.None)
                        {
                            _inventoryItem.ShowEmptyInventoryItem();
                        }
                        else
                        {
                            _outerwearInventoryItemStaticData = StaticDataManager.Instance.ForOuterwear(_outerwearId);
                            _inventoryItem.ShowOuterwearInventoryItem(_outerwearInventoryItemStaticData.Name,
                                _outerwearInventoryItemStaticData.MainIcon, _outerwearInventoryItemStaticData.Count,
                                _outerwearInventoryItemStaticData.MaxStackCount,
                                _outerwearInventoryItemStaticData.Weight,
                                _outerwearInventoryItemStaticData.DefenseValue,
                                _outerwearInventoryItemStaticData.TraitIcon, _outerwearId, this);
                        }

                        _isActivated = true;
                        HeroDataManager.Instance.ChangeOuterwear(_outerwearId);
                    }

                    break;

                case InventoryItemId.Medicine:
                    if (HeroDataManager.Instance.CheckNeedHeal())
                    {
                        _medicineId = _inventoryItem.MedicineInventoryItemView.Id;
                        _medicineInventoryItemStaticData = StaticDataManager.Instance.ForMedicine(_medicineId);
                        HeroDataManager.Instance.Heal(_medicineInventoryItemStaticData.Heal);
                        _inventoryItem.MedicineInventoryItemView.ReduceCount();

                        if (_inventoryItem.MedicineInventoryItemView.Count == 0)
                        {
                            _isActivated = true;
                            _inventoryItem.ShowEmptyInventoryItem();
                        }
                    }

                    break;
            }

            _activateButton.enabled = false;
            _deleteButton.enabled = false;
        }

        private void OnDeleteButtonClick()
        {
            _inventoryItem.ShowEmptyInventoryItem();
            _activateButton.enabled = false;
            _deleteButton.enabled = false;
        }

        private void OnCloseButtonClick() =>
            gameObject.SetActive(false);

        public void Show(string title, Sprite mainIcon, Sprite traitIcon, string traitValue, float weight,
            string activateButtonText, InventoryItem inventoryItem)
        {
            _titleText.text = title;
            _mainIconImage.sprite = mainIcon;
            _traitIconImage.sprite = traitIcon;
            _traitValueText.text = traitValue;
            _weightValueText.text = $"{weight} кг";
            _activateButtonText.text = activateButtonText;
            _inventoryItem = inventoryItem;
            _isActivated = false;
            _activateButton.enabled = true;
            _deleteButton.enabled = true;
            gameObject.SetActive(true);
        }
    }
}