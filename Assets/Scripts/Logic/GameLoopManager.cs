using Data;
using Data.Persons;
using UI.Screens.Main.WeaponsPanel;
using UI.Windows;
using UnityEngine;

namespace Logic
{
    public class GameLoopManager : MonoBehaviour
    {
        [SerializeField] private GameOverWindow _gameOverWindow;
        [SerializeField] private ItemsGenerator _itemsGenerator;
        [SerializeField] private ShootButton _shootButton;

        private void Awake()
        {
            HeroDataManager.Instance.Died += ToGameOverWindow;
            EnemyDataManager.Instance.Died += AddNewItem;
        }

        private void ToGameOverWindow() =>
            _gameOverWindow.Show();

        private void AddNewItem()
        {
            _itemsGenerator.CreateRandomItem();
            _shootButton.EnableButton();
        }
    }
}