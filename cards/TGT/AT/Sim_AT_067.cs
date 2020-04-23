

/* _BEGIN_TEMPLATE_
{
  "id": "AT_067",
  "name": [
    "猛犸人头领",
    "Magnataur Alpha"
  ],
  "text": [
    "同时对其攻击目标相邻的随从造成伤害。",
    "Also damages the minions next to whomever\nhe attacks."
  ],
  "cardClass": "WARRIOR",
  "type": "MINION",
  "cost": 4,
  "rarity": "EPIC",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2753
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_AT_067 : SimTemplate //* Magnataur Alpha
    {
        //Also damages the minions next to whomever he attacks.
        //done in minionAttacksMinion
    }
}