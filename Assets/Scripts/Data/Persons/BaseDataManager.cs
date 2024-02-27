using System;
using UnityEngine;

namespace Data.Persons
{
    public abstract class BaseDataManager : MonoBehaviour
    {
        private const float INITIAL_HEALTH = 100f;
        private const float ZERO_HEALTH = 0f;

        public float CurrentHealth { private set; get; }
        public float MaxHealth { private set; get; }

        public event Action HealthChanged;

        protected virtual void Initialize()
        {
            MaxHealth = INITIAL_HEALTH;
            CurrentHealth = INITIAL_HEALTH;
            HealthChanged?.Invoke();
        }

        public bool CheckNeedHeal() =>
            CurrentHealth < INITIAL_HEALTH;

        public void Heal(int count)
        {
            CurrentHealth += count;

            if (CurrentHealth > INITIAL_HEALTH)
                CurrentHealth = INITIAL_HEALTH;

            HealthChanged?.Invoke();
        }

        public void GetHit(int count)
        {
            CurrentHealth -= count;

            if (CurrentHealth <= ZERO_HEALTH)
            {
                CurrentHealth = ZERO_HEALTH;
                InvokeDeath();
            }

            HealthChanged?.Invoke();
        }

        protected abstract void InvokeDeath();
    }
}