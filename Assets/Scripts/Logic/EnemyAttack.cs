using Data;
using StaticData.ItemStaticDatas;
using UnityEngine;

namespace Logic
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private int _damage;

        private bool _isHeadAttack = true;
        private HeadgearInventoryItemStaticData _headgearInventoryItemStaticData;
        private OuterwearInventoryItemStaticData _outerwearInventoryItemStaticData;
        private int _resultDamage;

        public void Attack()
        {
            if (_isHeadAttack)
            {
                _headgearInventoryItemStaticData =
                    StaticDataManager.Instance.ForHeadgear(HeroDataManager.Instance.HeadgearId);
                _resultDamage = _damage - _headgearInventoryItemStaticData.DefenseValue;
                HeroDataManager.Instance.GetHit(_resultDamage);
            }
            else
            {
                _outerwearInventoryItemStaticData =
                    StaticDataManager.Instance.ForOuterwear(HeroDataManager.Instance.OuterwearId);
                _resultDamage = _damage - _outerwearInventoryItemStaticData.DefenseValue;
                HeroDataManager.Instance.GetHit(_resultDamage);
            }

            _isHeadAttack = !_isHeadAttack;
        }
    }
}