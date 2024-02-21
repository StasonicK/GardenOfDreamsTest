using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class InventoryItemView : MonoBehaviour
    {
        [SerializeField] private Image _iconImage;
        [SerializeField] private TextMeshProUGUI _countText;

        private float _weight;

        public void ConstructFull(Sprite icon, int count, float weight)
        {
            _iconImage.sprite = icon;
            _iconImage.gameObject.SetActive(true);
            _countText.text = count == 1 ? "" : $"{count}";
            _weight = weight;
        }

        public void ConstructEmpty()
        {
            _iconImage.gameObject.SetActive(false);
            _countText.text = "";
        }
    }
}