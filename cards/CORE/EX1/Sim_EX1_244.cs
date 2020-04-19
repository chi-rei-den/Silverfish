using HearthDb.Enums;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_244",
  "name": [
    "图腾之力",
    "Totemic Might"
  ],
  "text": [
    "使你的图腾获得+2生命值。",
    "Give your Totems +2 Health."
  ],
  "CardClass": "SHAMAN",
  "type": "SPELL",
  "cost": 0,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 830
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_244 : SimTemplate//totemic might
    {
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions;
            foreach (Minion t in temp)
            {
                if (t.handcard.card.Race == 21) // if minion is a totem, buff it
                {
                    p.minionGetBuffed(t, 0, 2);
                }
            }
        }

    }
}
