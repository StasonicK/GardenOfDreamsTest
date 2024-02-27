using Data.Persons;
using UI.Screens.Main.Inventory;
using UI.Windows;
using UnityEngine;

namespace Logic
{
    public class GameLoopManager : MonoBehaviour
    {
        [SerializeField] private GameOverWindow _gameOverWindow;
        [SerializeField] private ItemsContainer _itemsContainer;

        private void Awake()
        {
            HeroDataManager.Instance.Died += ToGameOverWindow;
            EnemyDataManager.Instance.Died += AddNewItem;
        }

        private void ToGameOverWindow() =>
            _gameOverWindow.Show();

        private void AddNewItem() =>
            _itemsContainer.CreateRandomItem();
    }
}