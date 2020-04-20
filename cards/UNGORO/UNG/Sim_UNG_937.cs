using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;
using HearthDb.Enums;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_937",
  "name": [
    "蛮鱼斥候",
    "Primalfin Lookout"
  ],
  "text": [
    "<b>战吼：</b>如果你控制其他任何鱼人，则<b>发现</b>一张鱼人牌。",
    "<b>Battlecry:</b> If you control another Murloc, <b>Discover</b> a Murloc."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41478
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_937 : SimTemplate //* Primalfin Lookout
	{
		//Battlecry: If you control another Murloc, Discover a Murloc.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                if (m.entitiyID == own.entitiyID) continue;
                if (m.handcard.card.Race == Race.MURLOC)
				{
					p.drawACard(CardIds.Collectible.Neutral.BluegillWarrior, own.own, true);
					break;
				}
            }
		}
	}
}