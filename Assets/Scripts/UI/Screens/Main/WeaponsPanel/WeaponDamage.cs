using Data;
using Data.InventoryItems.Ids;
using TMPro;
using UnityEngine;

namespace UI.Screens.Main.WeaponsPanel
{
    public class WeaponDamage : MonoBehaviour
    {
        [SerializeField] private WeaponId _weaponId;
        [SerializeField] private TextMeshProUGUI _damage;

        private void Awake() =>
            _damage.text = $"{StaticDataManager.Instance.ForWeapon(_weaponId).Damage}";
    }
}