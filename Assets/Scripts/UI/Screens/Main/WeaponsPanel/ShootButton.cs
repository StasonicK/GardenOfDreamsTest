using Logic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens.Main.WeaponsPanel
{
    public class ShootButton : MonoBehaviour
    {
        [SerializeField] private HeroAttack _heroAttack;

        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnShootButtonClick);
        }

        private void OnShootButtonClick()
        {
            if (_heroAttack.CanAttack())
            {
                _heroAttack.Attack();
                _button.enabled = false;
            }
        }

        public void EnableButton() =>
            _button.enabled = true;
    }
}