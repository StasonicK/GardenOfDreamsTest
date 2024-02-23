using TMPro;
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
        [SerializeField] private Button _equipButton;
        [SerializeField] private Button _deleteButton;
        [SerializeField] private Button _closeButton;
        [SerializeField] private TextMeshProUGUI _activateButtonText;

        private void Awake()
        {
            gameObject.SetActive(false);
            _equipButton.onClick.AddListener(OnEquipButtonClick);
            _deleteButton.onClick.AddListener(OnDeleteButtonClick);
            _closeButton.onClick.AddListener(OnCloseButtonClick);
        }

        private void OnEquipButtonClick()
        {
        }

        private void OnDeleteButtonClick()
        {
        }

        private void OnCloseButtonClick() =>
            gameObject.SetActive(false);

        public void Show(string title, Sprite mainIcon, Sprite traitIcon, string traitValue, float weight,
            string activateButtonText)
        {
            _titleText.text = title;
            _mainIconImage.sprite = mainIcon;
            _traitIconImage.sprite = traitIcon;
            _traitValueText.text = traitValue;
            _weightValueText.text = $"{weight} кг";
            _activateButtonText.text = activateButtonText;
            gameObject.SetActive(true);
        }
    }
}