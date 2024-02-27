using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens.Main.Persons
{
    public class HealthBar : MonoBehaviour
    {
        private Slider _slider;

        private void Awake() =>
            _slider = GetComponent<Slider>();

        public void SetValue(float current, float max) =>
            _slider.value = current / max;
    }
}