using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens.Main.Persons
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        public void SetValue(float current, float max) =>
            _slider.value = current / max;
    }
}