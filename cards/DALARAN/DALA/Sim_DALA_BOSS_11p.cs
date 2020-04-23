
/* _BEGIN_TEMPLATE_
{
  "id": "DALA_BOSS_11p",
  "name": [
    "背刺偷袭",
    "Backstabber"
  ],
  "text": [
    "<b>被动英雄技能</b>\n每当一个<b>潜行</b>的随从被召唤，使其获得+1攻击力。",
    "[x]<b>Passive Hero Power</b>\nWhenever a <b><b>Stealth</b>ed</b>\nminion is summoned,\ngive it +1 Attack."
  ],
  "CardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 0,
  "rarity": null,
  "set": "DALARAN",
  "collectible": null,
  "dbfId": 53716
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_DALA_BOSS_11p : SimTemplate //* 背刺偷袭 Backstabber
    {
        //[x]<b>Passive Hero Power</b>Whenever a <b><b>Stealth</b>ed</b>minion is summoned,give it +1 Attack.
        //<b>被动英雄技能</b>每当一个<b>潜行</b>的随从被召唤，使其获得+1攻击力。
    }
}