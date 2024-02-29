using System;
using UnityEngine;

namespace Logic
{
    public abstract class BaseDataManager : MonoBehaviour
    {
        private const float ZERO_HEALTH = 0f;

        private float _maxHealth;

        public float CurrentHealth { protected set; get; }
        public float MaxHealth { protected set; get; }

        protected event Action HealthChanged;

        protected void Initialize(float maxHealth)
        {
            _maxHealth = maxHealth;
            MaxHealth = _maxHealth;
            CurrentHealth = _maxHealth;
            HealthChanged?.Invoke();
        }

        public bool CheckNeedHeal() =>
            CurrentHealth < _maxHealth;

        public void Heal(int count)
        {
            CurrentHealth += count;

            if (CurrentHealth > _maxHealth)
                CurrentHealth = _maxHealth;

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