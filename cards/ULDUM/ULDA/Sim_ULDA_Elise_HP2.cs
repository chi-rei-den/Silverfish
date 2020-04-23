/* _BEGIN_TEMPLATE_
{
  "id": "ULDA_Elise_HP2",
  "name": [
    "德鲁伊教学",
    "Druidic Teaching"
  ],
  "text": [
    "<b>英雄技能</b>\n恢复#2点生命值。此时如果目标拥有所有生命值，抽一张牌。",
    "[x]<b>Hero Power</b>\nRestore #2 Health, then\ndraw a card if the target\nis at full Health."
  ],
  "cardClass": "DRUID",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "ULDUM",
  "collectible": null,
  "dbfId": 57001
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ULDA_Elise_HP2 : SimTemplate //* 德鲁伊教学 Druidic Teaching
    {
        //[x]<b>Hero Power</b>Restore #2 Health, thendraw a card if the targetis at full Health.
        //<b>英雄技能</b>恢复#2点生命值。此时如果目标拥有所有生命值，抽一张牌。
    }
}