using System;
using UnityEngine;

namespace Logic
{
    public abstract class BaseDataManager : MonoBehaviour
    {
        private const float INITIAL_HEALTH = 100f;
        private const float ZERO_HEALTH = 0f;

        public float CurrentHealth { protected set; get; }
        public float MaxHealth { protected set; get; }

        public event Action HealthChanged;

        public virtual void Initialize()
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

        protected void InvokeHealthChanged() =>
            HealthChanged?.Invoke();

        protected abstract void InvokeDeath();
    }
}