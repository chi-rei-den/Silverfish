using System;
using System.Collections.Generic;
using System.Text;
/* _BEGIN_TEMPLATE_
{
  "id": "DAL_739",
  "name": [
    "地精跟班",
    "Goblin Lackey"
  ],
  "text": [
    "<b>战吼：</b>\n使一个友方随从获得+1攻击力和<b>突袭</b>。",
    "<b>Battlecry:</b> Give a friendly minion +1 Attack and <b>Rush</b>."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 1,
  "rarity": null,
  "set": "DALARAN",
  "collectible": null,
  "dbfId": 52897
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
 class Sim_DAL_739 : SimCard //地精跟班
 {
 // 战吼：使一个友方随从获得+1攻击力和突袭。
 public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
 {
 // if (target != null && own.own) p.minionGetBuffed(target, 1, 0);
 // p.minionGetRush(target);
 // if (target == null) return;
 // p.minionGetBuffed(target, 1, 0);
 // p.minionGetRush(target);
 if (target != null && own.own)
 {
 p.minionGetBuffed(target, 1, 0);
 p.minionGetRush(target); 
 }
 }
 }
}