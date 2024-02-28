using System;
using Data;
using Data.Persons;
using UnityEngine;

namespace Logic
{
    public class EnemyDataManager : BaseDataManager
    {
        private const string FILE_NAME = "EnemyData.dat";

        private static EnemyDataManager _instance;

        public event Action Died;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            Instance.Initialize();
        }

        private void OnDestroy()
        {
            Debug.Log("EnemyDataManager OnDestroy");
            SaveLoadManager.SaveJsonData(new EnemyData(MaxHealth, CurrentHealth), FILE_NAME);
            Debug.Log("EnemyDataManager Saved");
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

        public override void Initialize()
        {
            var enemyData = new EnemyData(MaxHealth, CurrentHealth);

            if (SaveLoadManager.LoadJsonData<EnemyData>(FILE_NAME, ref enemyData))
            {
                MaxHealth = enemyData.MaxHealth;
                CurrentHealth = enemyData.CurrentHealth;
            }
            else
            {
                base.Initialize();
            }

            InvokeHealthChanged();
        }

        protected override void InvokeDeath() =>
            Died?.Invoke();
    }
}