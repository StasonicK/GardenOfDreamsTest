using TMPro;
using UnityEngine;

namespace UI.Screens.Main.Persons
{
    public abstract class HealthChanger : MonoBehaviour
    {
        [SerializeField] protected TextMeshProUGUI _healthValue;
        [SerializeField] protected HealthBar _healthBar;

        protected abstract void UpdateHealthBar();
    }
}