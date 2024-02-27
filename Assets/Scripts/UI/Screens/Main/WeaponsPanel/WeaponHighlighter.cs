using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens.Main.WeaponsPanel
{
    public class WeaponHighlighter : MonoBehaviour
    {
        [SerializeField] private Image _selected;
        [SerializeField] private Image _unselected;

        public void Select()
        {
            _selected.gameObject.SetActive(true);
            _unselected.gameObject.SetActive(false);
        }

        public void Unselect()
        {
            _unselected.gameObject.SetActive(true);
            _selected.gameObject.SetActive(false);
        }
    }
}