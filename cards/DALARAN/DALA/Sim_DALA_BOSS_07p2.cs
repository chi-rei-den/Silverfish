
/* _BEGIN_TEMPLATE_
{
  "id": "DALA_BOSS_07p2",
  "name": [
    "飞向高空",
    "Flying!"
  ],
  "text": [
    "<b>被动英雄技能</b>\n贝尔纳拉将在2回合内着陆<i>（还剩",
    "[x]<b>Passive Hero Power</b>\nBelnaara will land in 2 turns.\n<i>("
  ],
  "CardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 0,
  "rarity": null,
  "set": "DALARAN",
  "collectible": null,
  "dbfId": 56700
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_DALA_BOSS_07p2 : SimTemplate //* 飞向高空 Flying!
    {
        //[x]<b>Passive Hero Power</b>Belnaara will land in 2 turns.<i>(2 turns remaining)</i>
        //<b>被动英雄技能</b>贝尔纳拉将在2回合内着陆<i>（还剩2回合）</i>。
    }
}