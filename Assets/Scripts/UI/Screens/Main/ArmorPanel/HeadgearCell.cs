using Data;
using Data.InventoryItems.Ids;
using Logic;
using StaticData.ItemStaticDatas;

namespace UI.Screens.Main.ArmorPanel
{
    public class HeadgearCell : BaseArmorCell
    {
        private HeadgearId _headgearId;
        private HeadgearInventoryItemStaticData _headgearInventoryItemStaticData;

        private void Awake()
        {
            HeroDataManager.Instance.HeadgearChanged += ChangeArmor;
            ChangeArmor();
        }

        protected override void ChangeArmor()
        {
            _headgearId = HeroDataManager.Instance.HeadgearId;
            _headgearInventoryItemStaticData = StaticDataManager.Instance.ForHeadgear(_headgearId);
            _armorIconImage.sprite = _headgearInventoryItemStaticData.MainIcon;
            _armorValueText.text = $"{_headgearInventoryItemStaticData.DefenseValue}";
        }
    }
}