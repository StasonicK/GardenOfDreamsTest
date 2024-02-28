using System;

namespace Data.Persons
{
    [Serializable]
    public class PersonData
    {
        public float MaxHealth;
        public float CurrentHealth;

        public PersonData()
        {
        }

        public PersonData(float maxHealth, float currentHealth)
        {
            MaxHealth = maxHealth;
            CurrentHealth = currentHealth;
        }
    }
}