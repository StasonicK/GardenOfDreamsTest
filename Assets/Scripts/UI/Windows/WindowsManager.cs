using Audio;
using UnityEngine;

namespace UI.Windows
{
    public class WindowsManager : MonoBehaviour
    {
        [SerializeField] private InventoryItemWindow _inventoryItemWindow;
        [SerializeField] private GameOverWindow _gameOverWindow;

        private static WindowsManager _instance;

        public static WindowsManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<WindowsManager>();

                return _instance;
            }
        }

        public void Show(WindowId windowId)
        {
            switch (windowId)
            {
                case WindowId.InventoryItemWindowId:
                    _inventoryItemWindow.Show();
                    break;

                case WindowId.GameOverWindowId:
                    _gameOverWindow.Show();
                    break;
            }

            AudioManager.Instance.PlayAudio(AudioTrack.OpenWindowSoundFx);
        }
    }
}