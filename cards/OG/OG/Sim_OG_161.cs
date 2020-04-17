using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_161",
  "name": [
    "腐化先知",
    "Corrupted Seer"
  ],
  "text": [
    "<b>战吼：</b>对所有非鱼人随从造成2点伤害。",
    "<b>Battlecry:</b> Deal 2 damage to all non-Murloc minions."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 6,
  "rarity": "RARE",
  "set": "OG",
  "collectible": true,
  "dbfId": 38545
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_161 : SimCard //* Corrupted Seer
    {
        //Battlecry: Deal 2 damage to all non-Murloc minions.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            foreach (Minion m in p.ownMinions)
            {
                if ((TAG_RACE)m.handcard.card.race != TAG_RACE.MURLOC) p.minionGetDamageOrHeal(m, 2);
            }
            foreach (Minion m in p.enemyMinions)
            {
                if ((TAG_RACE)m.handcard.card.race != TAG_RACE.MURLOC) p.minionGetDamageOrHeal(m, 2);
            }
		}
	}
}