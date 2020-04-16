using System;
using System.Collections.Generic;
using System.Text;
/* _BEGIN_TEMPLATE_
{
  "id": "ULD_171",
  "name": [
    "图腾潮涌",
    "Totemic Surge"
  ],
  "text": [
    "使你的图腾获得+2攻击力。",
    "Give your Totems +2 Attack."
  ],
  "cardClass": "SHAMAN",
  "type": "SPELL",
  "cost": 0,
  "rarity": "COMMON",
  "set": "ULDUM",
  "collectible": true,
  "dbfId": 53978
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
class Sim_ULD_171 : SimTemplate //* 图腾潮涌 Totemic Surge
{
//Give your Totems +2 Attack.
//使你的图腾获得+2攻击力。
public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
{
List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions;
foreach (Minion t in temp)
{
if (t.handcard.card.race == 21) 
{
p.minionGetBuffed(t, 2, 0);
}
}
}




}
}
