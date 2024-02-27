using System.Collections;
using Logic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens.Main.WeaponsPanel
{
    public class ShootButton : MonoBehaviour
    {
        [SerializeField] private HeroAttack _heroAttack;
        [SerializeField] private EnemyAttack _enemyAttack;
        [SerializeField] private float _enemyAttackDelay = 1f;

        private Button _button;
        private WaitForSeconds _waitForSeconds;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnShootButtonClick);
            _waitForSeconds = new WaitForSeconds(_enemyAttackDelay);
        }

        private void OnShootButtonClick()
        {
            if (_heroAttack.CanAttack())
            {
                _heroAttack.Attack();
                _button.enabled = false;
                StartCoroutine(CoroutineEnemyAttack());
            }
        }

        public void EnableButton() =>
            _button.enabled = true;

        private IEnumerator CoroutineEnemyAttack()
        {
            yield return _waitForSeconds;
            _enemyAttack.Attack();
        }
    }
}