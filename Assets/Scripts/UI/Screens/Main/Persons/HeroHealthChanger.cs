using Data.Persons;

namespace UI.Screens.Main.Persons
{
    public class HeroHealthChanger : HealthChanger
    {
        private void Awake()
        {
            HeroDataManager.Instance.HealthChanged += UpdateHealthBar;
            UpdateHealthBar();
        }

        protected override void UpdateHealthBar()
        {
            _healthValue.text = $"{HeroDataManager.Instance.CurrentHealth}";
            _healthBar.SetValue(HeroDataManager.Instance.CurrentHealth, HeroDataManager.Instance.MaxHealth);
        }
    }
}