using Data;
using Logic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Windows
{
    public class GameOverWindow : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _leaveGameButton;
        [SerializeField] private ItemsGenerator _itemsGenerator;

        private void Awake()
        {
            _restartButton.onClick.AddListener(Restart);
            _leaveGameButton.onClick.AddListener(LeaveGame);
        }

        private void Restart()
        {
            _itemsGenerator.Generate();
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