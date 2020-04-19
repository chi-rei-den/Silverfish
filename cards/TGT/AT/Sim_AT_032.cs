using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_032",
  "name": [
    "走私商贩",
    "Shady Dealer"
  ],
  "text": [
    "<b>战吼：</b>如果你控制任何海盗，便获得+1/+1。",
    "<b>Battlecry:</b> If you have a Pirate, gain +1/+1."
  ],
  "cardClass": "ROGUE",
  "type": "MINION",
  "cost": 3,
  "rarity": "RARE",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2768
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_032 : SimTemplate //* Shady Dealer
	{
		//Battlecry: If you have a Pirate, gain +1/+1.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                if ((Race)m.handcard.card.Race == Race.PIRATE)
                {
                    p.minionGetBuffed(own, 1, 1);
					break;
                }
            }
        }
    }
}