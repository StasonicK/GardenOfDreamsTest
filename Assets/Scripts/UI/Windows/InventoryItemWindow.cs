using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Windows
{
    public class InventoryItemWindow : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _titleText;
        [SerializeField] private Image _iconImage;
        [SerializeField] private Image _traitImage;
        [SerializeField] private TextMeshProUGUI _traitValueText;
        [SerializeField] private TextMeshProUGUI _weightValueText;
        [SerializeField] private Button _equipButton;
        [SerializeField] private Button _deleteButton;

        private void Awake()
        {
            gameObject.SetActive(false);
            _equipButton.onClick.AddListener(OnEquipButtonClick);
            _deleteButton.onClick.AddListener(OnDeleteButtonClick);
        }

        private void OnEquipButtonClick()
        {
        }

        private void OnDeleteButtonClick()
        {
        }

        public void Show(string title, Sprite iconSprite, Sprite traitSprite, string traitValue, float weight)
        {
            _titleText.text = title;
            _iconImage.sprite = iconSprite;
            _traitImage.sprite = traitSprite;
            _traitValueText.text = traitValue;
            _weightValueText.text = $"{weight} кг";
            gameObject.SetActive(true);
        }
    }
}