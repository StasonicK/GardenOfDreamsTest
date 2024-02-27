using Data.Persons;
using UI.Screens.Main.Inventory;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Windows
{
    public class GameOverWindow : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _leaveGameButton;
        [SerializeField] private ItemsContainer _itemsContainer;

        private void Awake()
        {
            _restartButton.onClick.AddListener(Restart);
            _leaveGameButton.onClick.AddListener(LeaveGame);
        }

        private void Restart()
        {
            _itemsContainer.Initialize();
            HeroDataManager.Instance.Initialize();
            EnemyDataManager.Instance.Initialize();
            gameObject.SetActive(false);
        }

        private void LeaveGame() =>
            Application.Quit();

        public void Show() =>
            gameObject.SetActive(true);
    }
}