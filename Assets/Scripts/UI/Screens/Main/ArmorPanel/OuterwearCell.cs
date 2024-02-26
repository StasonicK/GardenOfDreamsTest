using Data;
using Data.Hero;
using Data.InventoryItems.Ids;
using Data.InventoryItems.ItemStaticDatas;

namespace UI.Screens.Main.ArmorPanel
{
    public class OuterwearCell : BaseArmorCell
    {
        private OuterwearId _outerwearId;
        private OuterwearInventoryItemStaticData _outerwearInventoryItemStaticData;

        private void Awake()
        {
            HeroDataManager.Instance.OuterwearChanged += ChangeArmor;
            ChangeArmor();
        }

        protected override void ChangeArmor()
        {
            _outerwearId = HeroDataManager.Instance.OuterwearId;
            _outerwearInventoryItemStaticData = StaticDataManager.Instance.ForOuterwear(_outerwearId);
            _armorIconImage.sprite = _outerwearInventoryItemStaticData.MainIcon;
            _armorValueText.text = $"{_outerwearInventoryItemStaticData.DefenseValue}";
        }
    }
}