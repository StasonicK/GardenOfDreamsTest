using Data.InventoryItems.Ids;
using Logic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens.Main.WeaponsPanel
{
    public class WeaponsSelector : MonoBehaviour
    {
        [SerializeField] private Button _pistolButton;
        [SerializeField] private Button _assaultRifleButton;
        [SerializeField] private WeaponHighlighter _pistolWeaponHighlighter;
        [SerializeField] private WeaponHighlighter _assaultRifleWeaponHighlighter;

        private WeaponId _weaponId;

        private void Awake()
        {
            _pistolButton.onClick.AddListener(OnPistolButtonClick);
            _assaultRifleButton.onClick.AddListener(OnAssaultRifleButtonClick);
            HeroDataManager.Instance.WeaponChanged += HighlightWeaponSlot;
            HighlightWeaponSlot();
        }

        private void HighlightWeaponSlot()
        {
            switch (HeroDataManager.Instance.WeaponId)
            {
                case WeaponId.Pistol:
                    _pistolWeaponHighlighter.Select();
                    _assaultRifleWeaponHighlighter.Unselect();
                    _weaponId = WeaponId.Pistol;
                    break;
                case WeaponId.AssaultRifle:
                    _assaultRifleWeaponHighlighter.Select();
                    _pistolWeaponHighlighter.Unselect();
                    _weaponId = WeaponId.AssaultRifle;
                    break;
            }
        }

        private void OnPistolButtonClick()
        {
            if (_weaponId == WeaponId.Pistol)
                return;

            HeroDataManager.Instance.ChangeWeapon(WeaponId.Pistol);
        }

        private void OnAssaultRifleButtonClick()
        {
            if (_weaponId == WeaponId.AssaultRifle)
                return;

            HeroDataManager.Instance.ChangeWeapon(WeaponId.AssaultRifle);
        }
    }
}