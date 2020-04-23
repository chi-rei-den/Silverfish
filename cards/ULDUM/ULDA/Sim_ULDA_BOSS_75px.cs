/* _BEGIN_TEMPLATE_
{
  "id": "ULDA_BOSS_75px",
  "name": [
    "捕猎弱者",
    "Hunt the Weak"
  ],
  "text": [
    "<b>英雄技能</b>\n对一个随从造成$",
    "[x]<b>Hero Power</b>\nDeal $"
  ],
  "cardClass": "HUNTER",
  "type": "HERO_POWER",
  "cost": 1,
  "rarity": null,
  "set": "ULDUM",
  "collectible": null,
  "dbfId": 59079
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ULDA_BOSS_75px : SimTemplate //* 捕猎弱者 Hunt the Weak
    {
        //[x]<b>Hero Power</b>Deal $2 damage to a minion andgain 2 bonus damage. If it dies,lose all bonus damage.
        //<b>英雄技能</b>对一个随从造成$2点伤害并获得2点额外伤害。如果该随从死亡，则失去所有额外伤害。
    }
}