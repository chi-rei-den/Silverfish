using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_049",
  "name": [
    "雷霆崖勇士",
    "Thunder Bluff Valiant"
  ],
  "text": [
    "<b>激励：</b>使你的图腾获得+2攻击力。",
    "<b>Inspire:</b> Give your Totems +2 Attack."
  ],
  "cardClass": "SHAMAN",
  "type": "MINION",
  "cost": 5,
  "rarity": "RARE",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2615
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_049 : SimTemplate //* Thunder Bluff Valiant
	{
		//Inspire: Give your Totems +2 Attack.

		public override void onInspire(Playfield p, Minion m, bool own)
        {
			if (m.own == own)
			{
				List<Minion> temp = (own) ? p.ownMinions : p.enemyMinions;
				foreach (Minion mnn in temp)
				{
					if ((Race)mnn.handcard.card.Race == Race.TOTEM)
					{
						p.minionGetBuffed(mnn, 2, 0);
					}
				}
			}
        }
	}
}