using Logic;

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
            if (HeroDataManager.Instance.MaxHealth == 0)
                return;

            _healthValue.text = $"{HeroDataManager.Instance.CurrentHealth}";
            _healthBar.SetValue(HeroDataManager.Instance.CurrentHealth, HeroDataManager.Instance.MaxHealth);
        }
    }
}