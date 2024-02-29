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

        private static GameLoopManager _instance;

        public static GameLoopManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<GameLoopManager>();

                return _instance;
            }
        }

        private void Awake()
        {
            DontDestroyOnLoad(this);
            HeroDataManager.Instance.Died += ToGameOverWindow;
            EnemyDataManager.Instance.Died += AddNewItem;
        }

        public void Restart()
        {
            _itemsGenerator.Generate();
            HeroDataManager.Instance.InitializeRestart();
            EnemyDataManager.Instance.InitializeRestart();
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