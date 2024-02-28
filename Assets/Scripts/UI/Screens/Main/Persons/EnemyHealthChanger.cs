using Logic;

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
            if (EnemyDataManager.Instance.MaxHealth == 0)
                return;

            _healthValue.text = $"{EnemyDataManager.Instance.CurrentHealth}";
            _healthBar.SetValue(EnemyDataManager.Instance.CurrentHealth, EnemyDataManager.Instance.MaxHealth);
        }
    }
}