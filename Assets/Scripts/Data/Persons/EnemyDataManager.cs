using System;

namespace Data.Persons
{
    public class EnemyDataManager : BaseDataManager
    {
        private static EnemyDataManager _instance;

        public event Action Died;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            Instance.Initialize();
        }

        public static EnemyDataManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<EnemyDataManager>();

                return _instance;
            }
        }

        protected override void InvokeDeath()
        {
            Died?.Invoke();
        }
    }
}