using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens.Main.ArmorPanel
{
    public abstract class BaseArmorCell : MonoBehaviour
    {
        [SerializeField] protected Image _armorIconImage;
        [SerializeField] protected TextMeshProUGUI _armorValueText;

        protected abstract void ChangeArmor();
    }
}