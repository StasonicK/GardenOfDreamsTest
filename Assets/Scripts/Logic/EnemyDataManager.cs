using System;
using Data;
using Data.Persons;

namespace Logic
{
    public class EnemyDataManager : BaseDataManager
    {
        private const string FILE_NAME = "EnemyData.dat";
        private const float INITIAL_HEALTH = 100f;

        private static EnemyDataManager _instance;

        public event Action Died;
        public event Action HealthChanged;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            base.HealthChanged += () => HealthChanged?.Invoke();
            Instance.Initialize(INITIAL_HEALTH);
        }

        private void OnDestroy() =>
            SaveLoadManager.SaveJsonData(new EnemyData(MaxHealth, CurrentHealth), FILE_NAME);

        public static EnemyDataManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<EnemyDataManager>();

                return _instance;
            }
        }

        public void Initialize()
        {
            var enemyData = new EnemyData(MaxHealth, CurrentHealth);

            if (SaveLoadManager.LoadJsonData<EnemyData>(FILE_NAME, ref enemyData))
            {
                MaxHealth = enemyData.MaxHealth;
                CurrentHealth = enemyData.CurrentHealth;
                HealthChanged?.Invoke();
            }
            else
            {
                base.Initialize(INITIAL_HEALTH);
            }
        }

        public void InitializeRestart() =>
            base.Initialize(INITIAL_HEALTH);

        protected override void InvokeDeath() =>
            Died?.Invoke();
    }
}