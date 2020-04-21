using HearthDb.Enums;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "DS1_178",
  "name": [
    "苔原犀牛",
    "Tundra Rhino"
  ],
  "text": [
    "你的野兽获得<b>冲锋</b>。",
    "Your Beasts have <b>Charge</b>."
  ],
  "CardClass": "HUNTER",
  "type": "MINION",
  "cost": 5,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 699
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_DS1_178 : SimTemplate //tundrarhino
	{

//    eure wildtiere haben ansturm/.
        //todo charge?
        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.anzOwnTundrarhino++;
                foreach (Minion m in p.ownMinions)
                {
                    if (m.handcard.card.Race == Race.PET) p.minionGetCharge(m);
                }
            }
            else
            {
                p.anzEnemyTundrarhino++;
                foreach (Minion m in p.enemyMinions)
                {
                    if (m.handcard.card.Race == Race.PET) p.minionGetCharge(m);
                }
            }
        }

        public override void onAuraEnds(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.anzOwnTundrarhino--;
                foreach (Minion m in p.ownMinions)
                {
                    if (m.handcard.card.Race == Race.PET) p.minionLostCharge(m);
                }
            }
            else
            {
                p.anzEnemyTundrarhino--;
                foreach (Minion m in p.enemyMinions)
                {
                    if (m.handcard.card.Race == Race.PET) p.minionLostCharge(m);
                }
            }
        }
	}
}