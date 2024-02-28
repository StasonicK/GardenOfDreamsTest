using System;

namespace Data.Persons
{
    [Serializable]
    public class EnemyData : PersonData
    {
        public EnemyData()
        {
        }

        public EnemyData(float maxHealth, float currentHealth) : base(maxHealth, currentHealth)
        {
        }
    }
}