using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "LOE_039",
  "name": [
    "A3型机械金刚",
    "Gorillabot A-3"
  ],
  "text": [
    "<b>战吼：</b>如果你控制其他任何机械，则<b>发现</b>一张机械牌。",
    "<b>Battlecry:</b> If you control another Mech, <b>Discover</b> a Mech."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "LOE",
  "collectible": true,
  "dbfId": 2911
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_LOE_039 : SimTemplate //* Gorillabot A-3
	{
		//Battlecry: If you control another Mech, Discover a Mech.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                if (m.entitiyID == own.entitiyID) continue;
                if ((Race)m.handcard.card.Race == Race.MECHANICAL)
				{
					p.drawACard(CardIds.Collectible.Neutral.SpiderTank, own.own, true);
					break;
				}
            }
		}
	}
}