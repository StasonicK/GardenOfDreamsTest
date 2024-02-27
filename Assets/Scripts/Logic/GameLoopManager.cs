using Data.Persons;
using UnityEngine;

namespace Logic
{
    public class GameLoopManager : MonoBehaviour
    {
        private void Awake()
        {
            HeroDataManager.Instance.Died += ToGameOverWindow;
            EnemyDataManager.Instance.Died += AddNewItem;
        }

        private void ToGameOverWindow()
        {
        }

        private void AddNewItem()
        {
        }
    }
}