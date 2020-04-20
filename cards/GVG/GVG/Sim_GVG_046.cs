using System;
using System.Collections.Generic;
using System.Text;
using HearthDb.Enums;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_046",
  "name": [
    "百兽之王",
    "King of Beasts"
  ],
  "text": [
    "<b>嘲讽，战吼：</b>你每控制一个其他野兽，便获得+1攻击力。",
    "<b>Taunt</b>. <b>Battlecry:</b> Gain +1 Attack for each other Beast you have."
  ],
  "cardClass": "HUNTER",
  "type": "MINION",
  "cost": 5,
  "rarity": "RARE",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2014
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_046 : SimTemplate //* King of Beasts
    {
        //   Taunt Battlecry: Gain +1 Attack for each other Beast you have.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            int bonusattack = 0;
            List<Minion> temp  = (own.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                if (m.entitiyID == own.entitiyID) continue;
                if (m.handcard.card.Race == Race.PET) bonusattack++;
            }
            p.minionGetBuffed(own, bonusattack, 0);
        }
    }
}