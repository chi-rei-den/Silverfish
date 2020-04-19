using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_668t2",
  "name": [
    "魅影歹徒",
    "Doppelgangster"
  ],
  "text": [
    "<b>战吼：</b>召唤该随从的两个复制。",
    "<b>Battlecry:</b> Summon 2 copies of this minion."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "RARE",
  "set": "GANGS",
  "collectible": null,
  "dbfId": 42213
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_668t2 : SimTemplate //* Doppelgangster
	{
		// Battlecry: Summon 2 copies of this minion.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            p.callKid(m.handcard.card, m.zonepos, m.own);
            p.callKid(m.handcard.card, m.zonepos, m.own);
            List<Minion> temp = (m.own) ? p.ownMinions : p.enemyMinions;
            int count = 0;
            foreach (Minion mnn in temp)
            {
                if (mnn.name == CardIds.Collectible.Neutral.Doppelgangster && m.entitiyID != mnn.entitiyID && mnn.playedThisTurn)
                {
                    mnn.setMinionToMinion(m);
                    count++;
                    if (count >= 2) break;
                }
            }
        }
    }
}