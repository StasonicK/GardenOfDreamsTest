using Data.Persons;

namespace UI.Screens.Main.Persons
{
    public class EnemyHealthChanger : HealthChanger
    {
        private void Awake()
        {
            EnemyDataManager.Instance.HealthChanged += UpdateHealthBar;
            UpdateHealthBar();
        }

        protected override void UpdateHealthBar()
        {
            _healthValue.text = $"{EnemyDataManager.Instance.CurrentHealth}";
            _healthBar.SetValue(EnemyDataManager.Instance.CurrentHealth, EnemyDataManager.Instance.MaxHealth);
        }
    }
}